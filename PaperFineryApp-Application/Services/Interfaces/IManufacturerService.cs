using PaperFineryApp_Domain.Dtos.RequestDto;
using PaperFineryApp_Domain.Dtos.ResponseDto;
using PaperFineryApp_Domain.Model;
using PaperFineryApp_Shared;

namespace PaperFineryApp_Application.Services.Interfaces
{
    public interface IManufacturerService
    {
        Task<StandardResponse<IEnumerable<ManufacturerResponseDto>>> GetAllManufacturers();
        Task<StandardResponse<string>> UpdateManufacturer(string manufacturerId, UpdateManufacturerDto updatManufacturer);
        Task<StandardResponse<Manufacturer>> GetManufacturerById(string manufacturerId);
    }
}
