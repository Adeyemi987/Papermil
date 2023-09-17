using Microsoft.EntityFrameworkCore;
using PaperFineryApp_Domain.Dtos.RequestDto;
using PaperFineryApp_Domain.Model;
using PaperFineryApp_Infrastructure.Persistence;
using PaperFineryApp_Infrastructure.Repository.Abstraction;

namespace PaperFineryApp_Infrastructure.Repository.Implementation
{
    public class OrderRepository: CommandRepository<Order>, IOrderRepository
    {
        private readonly DbSet<Order> _order;

        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {
            _order = dbContext.Set<Order>();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            var order = await _order.OrderBy(x => x.Id).ToListAsync();
            return order;
        }

        public async Task<Order> GetOrderByIdAsync(string id)
        {
            return await _order.Where(m => m.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
