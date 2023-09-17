using Microsoft.AspNetCore.Mvc;
using PaperFineryApp_Application.Services.Interfaces;
using PaperFineryApp_Domain.Dtos.RequestDto;
using Swashbuckle.AspNetCore.Annotations;

namespace PaperFineryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;
        public ManufacturersController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [SwaggerOperation(Description = "This endpoint updates manufactureres details")]
        [HttpPatch("update-manufacturerprofile")]
        public async Task<IActionResult> UpdateManufacturerProfile(string  manufacturerId, UpdateManufacturerDto updatemanu)
        {
            var result = await _manufacturerService.UpdateManufacturer(manufacturerId, updatemanu);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [SwaggerOperation(Description = "This endpoint retrieves all manufacturers details on record")]
        [HttpGet("get-allManufacturers")]
        public async Task<IActionResult> GetAllManufacturers()
        {
            var result = await _manufacturerService.GetAllManufacturers();
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [SwaggerOperation(Description = "This endpoint retrieves all manufacturer details by id")]
        [HttpGet("get-byid")]
        public async Task<IActionResult> GetAllManufacturbyId(string manufacturerId)
        {
            var result = await _manufacturerService.GetManufacturerById(manufacturerId);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}

