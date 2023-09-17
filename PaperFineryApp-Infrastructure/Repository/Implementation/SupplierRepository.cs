using Microsoft.EntityFrameworkCore;
using PaperFineryApp_Domain.Model;
using PaperFineryApp_Infrastructure.Persistence;
using PaperFineryApp_Infrastructure.Repository.Abstraction;
using PaperFineryApp_Shared.RequestParameter.ModelParameter;

namespace PaperFineryApp_Infrastructure.Repository.Implementation
{
    public class SupplierRepository : CommandRepository<Supplier>, ISupplierRepository
    {
        private readonly DbSet<Supplier> _supplier;

        public SupplierRepository(AppDbContext dbContext) : base(dbContext)
        {
            _supplier = dbContext.Set<Supplier>();
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            var suppliers = await _supplier.OrderBy(x => x.UserId).ToListAsync();
            return suppliers;
        }

        public async Task<Supplier> GetSupplierByIdAsync(string id)
        {
            return await _supplier.Where(m => m.UserId.Equals(id)).FirstOrDefaultAsync();
        }
    }
}