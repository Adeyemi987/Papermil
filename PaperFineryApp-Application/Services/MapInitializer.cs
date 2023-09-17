using AutoMapper;
using PaperFineryApp_Domain.Dtos.RequestDto;
using PaperFineryApp_Domain.Dtos.ResponseDto;
using PaperFineryApp_Domain.Model;

namespace PaperFineryApp_Application.Services
{
    public class MapInitializer : Profile
    {
        public MapInitializer()
        {
            CreateMap<Manufacturer, ManufacturerResponseDto>();
            CreateMap<UpdateManufacturerDto, Manufacturer>();
            CreateMap<Supplier, SupplierResponseDto>();
            CreateMap<Order, OrderResponseDto>();
            CreateMap<OrderRequestDto, Order>();
            CreateMap<User, RegisterResponseDto>();
            CreateMap<RegisterRequestDto, User>();
            CreateMap<string, Review>();
        }
    }
}

