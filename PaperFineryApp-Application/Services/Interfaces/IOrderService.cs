using PaperFineryApp_Domain.Dtos.RequestDto;
using PaperFineryApp_Domain.Dtos.ResponseDto;
using PaperFineryApp_Domain.Model;
using PaperFineryApp_Shared;

namespace PaperFineryApp_Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<StandardResponse<IEnumerable<OrderResponseDto>>> GetAllOrders();
        Task<StandardResponse<Order>> GetOrderId(string orderId);
        Task<StandardResponse<OrderResponseDto>> CreateOrder(string supplierId, OrderRequestDto createOrder);
    }
}
