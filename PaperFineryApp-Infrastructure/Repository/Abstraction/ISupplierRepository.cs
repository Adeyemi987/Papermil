using PaperFineryApp_Domain.Model;
using PaperFineryApp_Shared.RequestParameter.ModelParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFineryApp_Infrastructure.Repository.Abstraction
{
    public interface ISupplierRepository : ICommandIRepository<Supplier>
    {

        Task<Supplier> GetSupplierByIdAsync(string id);

        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
    }
}
