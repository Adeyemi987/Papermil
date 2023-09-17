using PaperFineryApp_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFineryApp_Infrastructure.Repository.Abstraction
{
    public interface IManufacturerRepository : ICommandIRepository<Manufacturer>
    {

        Task<Manufacturer> GetManufacterByIdAsync(string id);
        Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync();
    }
}
