using AutoMapper;
using Azure;
using Microsoft.Extensions.Logging;
using PaperFineryApp_Application.Services.Interfaces;
using PaperFineryApp_Domain.Dtos.RequestDto;
using PaperFineryApp_Domain.Dtos.ResponseDto;
using PaperFineryApp_Domain.Model;
using PaperFineryApp_Infrastructure.Persistence;
using PaperFineryApp_Infrastructure.Repository.Implementation;
using PaperFineryApp_Infrastructure.UnitOfWork.Abstraction;
using PaperFineryApp_Infrastructure.UnitOfWork.Implementation;
using PaperFineryApp_Shared;
using PaperFineryApp_Shared.RequestParameter.Common;
using PaperFineryApp_Shared.RequestParameter.ModelParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFineryApp_Application.Services.Implementations
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ManufacturerService> _logger;
        public ManufacturerService(AppDbContext appDbContext, IUnitOfWork unitOfWork, IMapper mapper, ILogger<ManufacturerService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<StandardResponse<string>> DeleteManufacturer(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<StandardResponse<IEnumerable<ManufacturerResponseDto>>> GetAllManufacturers()
        {
            var manufacturers = await _unitOfWork.ManufacturerRepository.GetAllManufacturersAsync();
            if (manufacturers == null)
            {
                return new StandardResponse<IEnumerable<ManufacturerResponseDto>> { Succeeded = false, Message = "null, no manufacturer datas found" };    
            }
            var manufacturersToReturn = _mapper.Map<IEnumerable<ManufacturerResponseDto>>(manufacturers);
            return StandardResponse<IEnumerable<ManufacturerResponseDto>>.Success("Successfully retrieved all manufacturers", manufacturersToReturn);
        }
        public async Task<StandardResponse<Manufacturer>> GetManufacturerById(string manufacturerId)
        {
            var getmanufacturer = await _unitOfWork.ManufacturerRepository.GetManufacterByIdAsync(manufacturerId);

            if (getmanufacturer == null)
            {
                return new StandardResponse<Manufacturer> { Succeeded = false, Message = "Manufacturer with this id: not found on record", Data = getmanufacturer };    
            }
            return new StandardResponse<Manufacturer> { Succeeded = true, Message = "Manufacturer successfully retrieved", Data = getmanufacturer}; 
        }
        public async Task<StandardResponse<string>> UpdateManufacturer(string manufacturerId, UpdateManufacturerDto updatManufacturer)
        {
            var getmanufacturer = await _unitOfWork.ManufacturerRepository.GetManufacterByIdAsync(manufacturerId);
            if (getmanufacturer == null)
            {
                return new StandardResponse<string> { Succeeded = false, Message = "Manufacturer with this id: not found on record" };
            }
            if (!string.IsNullOrEmpty(updatManufacturer.MinKilogramAccepted) && double.TryParse(updatManufacturer.FirstName, out double minKilogram))
            {
                getmanufacturer.MinKilogramAccepted = minKilogram;
            }
            if (!string.IsNullOrEmpty(updatManufacturer.PricePerKg) && decimal.TryParse(updatManufacturer.FirstName, out decimal unitPrice))
            {
                getmanufacturer.PricePerKg = unitPrice;
            }
            getmanufacturer.FirstName = !string.IsNullOrEmpty(updatManufacturer.FirstName) ? updatManufacturer.FirstName : getmanufacturer.FirstName;
            getmanufacturer.LastName = !string.IsNullOrEmpty(updatManufacturer.LastName) ? updatManufacturer.LastName : getmanufacturer.LastName;
            getmanufacturer.BusinessName = !string.IsNullOrEmpty(updatManufacturer.BusinessName) ? updatManufacturer.BusinessName : getmanufacturer.BusinessName;
            getmanufacturer.Address = !string.IsNullOrEmpty(updatManufacturer.Address) ? updatManufacturer.Address : getmanufacturer.Address;
            getmanufacturer.Profileimage = !string.IsNullOrEmpty(updatManufacturer.Profileimage) ? updatManufacturer.Profileimage : getmanufacturer.Profileimage;
            getmanufacturer.ModifiedAt = DateTime.UtcNow;
            _unitOfWork.ManufacturerRepository.Update(getmanufacturer);
            await _unitOfWork.SaveChangesAsync();
            return new StandardResponse<string> { Succeeded = true, Message = "Manufacturer Successfully updated" };
        }
    }
}
