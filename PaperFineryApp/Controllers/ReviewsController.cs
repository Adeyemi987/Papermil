using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaperFineryApp_Application.Services.Interfaces;
using PaperFineryApp_Domain.Model;
using System.Security.Claims;

namespace PaperFineryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviews;

        public ReviewsController(IReviewService reviews)
        { 
            _reviews = reviews;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateReview(string comment)
        {
            //watch this
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var responseFromCreation = await _reviews.CreateReview(userEmail,comment);
            return Ok(responseFromCreation);
        }
    }
}