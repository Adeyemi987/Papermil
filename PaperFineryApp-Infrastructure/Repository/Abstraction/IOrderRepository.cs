using PaperFineryApp_Domain.Model;

namespace PaperFineryApp_Infrastructure.Repository.Abstraction
{
    public interface IOrderRepository : ICommandIRepository<Order>
    {
        Task<Order> GetOrderByIdAsync(string id);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
    }
}
