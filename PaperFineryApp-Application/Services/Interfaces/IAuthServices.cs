using PaperFineryApp_Domain.Dtos.RequestDto;
using PaperFineryApp_Domain.Dtos.ResponseDto;
using PaperFineryApp_Domain.Model;
using PaperFineryApp_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFineryApp_Application.Services.Interfaces
{
    public interface IAuthServices
    {
        Task<StandardResponse<RegisterResponseDto>> RegisterUser(RegisterRequestDto register);
        Task<StandardResponse<UserLoginResponseDto>> Login(UserLoginRequestDto login);
        Task<IEnumerable<User>> GetUsers();
    }
}
