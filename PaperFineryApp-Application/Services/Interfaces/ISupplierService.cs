using PaperFineryApp_Domain.Dtos.ResponseDto;
using PaperFineryApp_Shared.RequestParameter.Common;
using PaperFineryApp_Shared.RequestParameter.ModelParameter;
using PaperFineryApp_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaperFineryApp_Domain.Dtos.RequestDto;
using PaperFineryApp_Domain.Model;

namespace PaperFineryApp_Application.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<StandardResponse<IEnumerable<SupplierResponseDto>>> GetAllSupplier();
        Task<StandardResponse<Supplier>> GeSupplierId(string supplierId);
        Task<StandardResponse<string>> DeleteManufacturer(string id);
        Task<StandardResponse<string>> UpdateSupplierr(string supplierId, UpdateSupplierDto updatSupplier);
    }
}
