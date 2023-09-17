using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PaperFineryApp_Application.Services.Interfaces;
using PaperFineryApp_Domain.Dtos.RequestDto;
using PaperFineryApp_Domain.Dtos.ResponseDto;
using PaperFineryApp_Domain.Enum;
using PaperFineryApp_Domain.Model;
using PaperFineryApp_Infrastructure.UnitOfWork.Abstraction;
using PaperFineryApp_Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PaperFineryApp_Application.Services.Implementations
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthServices(UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<StandardResponse<RegisterResponseDto>> RegisterUser([FromForm] RegisterRequestDto register)
        {
            var userExist = await _userManager.FindByEmailAsync(register.Email);
            var userExistByUsername = await _userManager.FindByNameAsync(register.UserName);

            if (userExist != null)
            {
                return new StandardResponse<RegisterResponseDto>()
                {
                    Succeeded = false,
                    Message = $"User with this email address '{register.Email}' already exists. Please select another email to proceed."
                };
            }
            else if (userExistByUsername != null)
            {
                return new StandardResponse<RegisterResponseDto>()
                {
                    Succeeded = false,
                    Message = $"User with this username '{register.UserName}' already exists. Please select another username."
                };
            }

            User user = _mapper.Map<User>(register);
            user.UserName = register.UserName;
            user.Email = register.Email;
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                if (register.UserType == UserType.Manufacturer)
                {
                    await _userManager.AddToRoleAsync(user, Role.Regular.ToString());
                    var findUser = await _userManager.FindByEmailAsync(register.Email);
                    var createManufacturer = new Manufacturer()
                    {
                        UserId = findUser.Id,
                        IsActive = true,
                    };
                     _unitOfWork.ManufacturerRepository.CreateAsync(createManufacturer);
                    await _unitOfWork.SaveChangesAsync();
                    return new StandardResponse<RegisterResponseDto>() { Succeeded = true, Message = "User successfully registered as a Manufacturer" };
                }
                await _userManager.AddToRoleAsync(user, Role.Regular.ToString());
                var getUser = await _userManager.FindByEmailAsync(register.Email);
                if (getUser == null)
                {
                    return new StandardResponse<RegisterResponseDto>() { Succeeded = false, Message = "no user found" };
                }
                var createSupplier = new Supplier()
                {
                    UserId = getUser.Id,
                    IsActive = true
                };
                await _unitOfWork.SupplierRepository.CreateAsync(createSupplier);
                await _unitOfWork.SaveChangesAsync();
                return new StandardResponse<RegisterResponseDto>() { Succeeded = true, Message = "User succeefully registered as a Supplier" };
            }
            return new StandardResponse<RegisterResponseDto>() { Succeeded = false, Message = "Registration Failed" };
        }

        public async Task<StandardResponse<UserLoginResponseDto>> Login(UserLoginRequestDto login)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(u => (u.Email == login.Email));         
            if (user == null)
            {              
                return new StandardResponse<UserLoginResponseDto>()
                {
                    Succeeded = false,
                    Message = $"There is no User with this Email: {login.Email} "
                };
            }
            var result = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!result)
            {
                return new StandardResponse<UserLoginResponseDto>()
                {
                    Succeeded = false,
                    Message = $"Invalid Password, Please re-enter your password correctly"
                };
            }
            var claims = new[]
            {
                new Claim("email", login.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id ),
                new Claim(ClaimTypes.Role, Role.Admin.ToString())
            };

            //Encrypt the token
            var keyString = Environment.GetEnvironmentVariable("KEY");
            if (string.IsNullOrEmpty(keyString))
            {
                throw new InvalidOperationException("The 'KEY' environment variable is not set.");
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
            return new StandardResponse<UserLoginResponseDto>()
            {
                Succeeded = true,
                Message = tokenAsString,
                Data = new UserLoginResponseDto()
                {
                    Email = login.Email
                }
            };
        }

        public async Task <IEnumerable<User>> GetUsers()
        {
            var getUsers = await _userManager.Users.ToListAsync();          
            if (getUsers == null)
            {
               return Enumerable.Empty<User>();
            }
            return getUsers;
        }
    }
}
