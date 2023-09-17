using Microsoft.AspNetCore.Http;
using PaperFineryApp_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFineryApp_Application.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Task<StandardResponse<string>> UploadImage(IEnumerable<IFormFile> images);
    }
}
