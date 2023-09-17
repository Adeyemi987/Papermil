using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaperFineryApp_Application.Services.Interfaces;
using PaperFineryApp_Domain.Dtos.RequestDto;
using Swashbuckle.AspNetCore.Annotations;

namespace PaperFineryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [SwaggerOperation(Description = "Thie endpoint retrieves all suppliers from record")]
        [HttpGet("get-allsuppliers")]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var result = await _supplierService.GetAllSupplier();
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [SwaggerOperation(Description = "Thie endpoint retrieves all suppliers from record")]
        [HttpGet("get-supplierById")]
        public async Task<IActionResult> GetASupplierById(string supplierId)
        {
            var result = await _supplierService.GeSupplierId(supplierId);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(result); 
        }

        [SwaggerOperation(Description = "Thie endpoint updates the supplier profile")]
        [HttpPatch("update-supplier")]
        public async Task<IActionResult> UpdateSupplierProfile(string supplierId, UpdateSupplierDto updatesupplier)
        {
            var result = await _supplierService.UpdateSupplierr(supplierId, updatesupplier);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
