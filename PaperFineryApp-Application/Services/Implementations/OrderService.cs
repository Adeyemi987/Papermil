using AutoMapper;
using PaperFineryApp_Application.Services.Interfaces;
using PaperFineryApp_Domain.Dtos.RequestDto;
using PaperFineryApp_Domain.Dtos.ResponseDto;
using PaperFineryApp_Domain.Enum;
using PaperFineryApp_Domain.Model;
using PaperFineryApp_Infrastructure.Repository.Abstraction;
using PaperFineryApp_Infrastructure.UnitOfWork.Abstraction;
using PaperFineryApp_Shared;
using PaperFineryApp_Shared.RequestParameter.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFineryApp_Application.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryService _cloudinaryService;
        public OrderService(IMapper mapper, IUnitOfWork unitOfWork, ICloudinaryService cloudinaryService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cloudinaryService = cloudinaryService;
        }


        public async Task<StandardResponse<OrderResponseDto>> CreateOrder(string supplierId, OrderRequestDto createOrder)
        {
            var findSupplierId = await _unitOfWork.SupplierRepository.GetSupplierByIdAsync(supplierId);
            if (findSupplierId == null)
            {
                return new StandardResponse<OrderResponseDto> { Succeeded = false, Message = "supplier data not found, you must be a registered supplier to be able to create an order" };
            }
            var productImage = await _cloudinaryService.UploadImage(createOrder.ProductImages);
            var generatedOrdereference = HelperCodeGenerator.GenerateOrderReference("ORDER_ref");
            var newOrder = new Order
            {
                DeliveryModesDesc = createOrder.DeliveryMode.ToString(),
                PapertypeDesc = createOrder.PaperTypes.ToString(),
                TotalWeightInkgDesc = createOrder.TotalWeightInKg.ToString(),
                OrderStatusDesc = OrderStatus.OrderInitiated.ToString(),
                SupplierLocation = createOrder.SupplierLocation,
                OrderReference = generatedOrdereference,
                productImageUrl = productImage.Data,
                OrderInitializationTime = DateTime.UtcNow,
                CreatedAt = DateTime.Now,
                SupplierId = supplierId,                   
            };
            await _unitOfWork.OrderRepository.CreateAsync(newOrder);
            await _unitOfWork.SaveChangesAsync();

            
            var orderToreturn = _mapper.Map<OrderResponseDto>(newOrder);
            return new StandardResponse<OrderResponseDto>
            {
                Succeeded = true,
                Message = $"successfully created a supply order for : {createOrder.TotalWeightInKg} KG of {createOrder.PaperTypes}: you will be notified about the progress of your supply request",
                Data = orderToreturn
            };
        }

        public async Task<StandardResponse<IEnumerable<OrderResponseDto>>> GetAllOrders()
        {
            var orders = await _unitOfWork.OrderRepository.GetAllOrdersAsync();
            if (orders == null)
            {
                return new StandardResponse<IEnumerable<OrderResponseDto>> { Succeeded = false, Message = "null, no ordee datas found" };
            }
            var ordersToReturn = _mapper.Map<IEnumerable<OrderResponseDto>>(orders);
            return new StandardResponse<IEnumerable<OrderResponseDto>> { Succeeded = true, Message = "Successfully retrieved orders", Data = ordersToReturn };
        }

        public async Task<StandardResponse<Order>> GetOrderId(string orderId)
        {
            var getOder = await _unitOfWork.OrderRepository.GetOrderByIdAsync(orderId);
            if (getOder == null)
            {
                return new StandardResponse<Order> { Succeeded = false, Message = "Order with this id: not found on record", Data = null };
            }
            return new StandardResponse<Order> { Succeeded = true, Message = "order successfully retrieved", Data = getOder };
        }


    }
}
