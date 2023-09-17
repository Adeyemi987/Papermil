using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaperFineryApp_Application.Services.Interfaces;
using PaperFineryApp_Domain.Dtos.RequestDto;

namespace PaperFineryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthServices _authService;

        public AuthenticationController(IAuthServices authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromForm]RegisterRequestDto register)
        {
            var result = await _authService.RegisterUser(register);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] UserLoginRequestDto login)
        {
            var result = await _authService.Login(login);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpGet("get-allUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _authService.GetUsers();
            if (result.Count() < 1)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
