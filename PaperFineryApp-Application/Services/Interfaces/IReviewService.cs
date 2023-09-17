using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFineryApp_Application.Services.Interfaces
{
    public interface IReviewService
    {
        Task<string> CreateReview(string userEmail, string comment);
    }
}
