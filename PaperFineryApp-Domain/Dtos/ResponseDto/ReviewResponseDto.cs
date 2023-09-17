using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFineryApp_Domain.Dtos.ResponseDto
{
    public class ReviewResponseDto
    {
        public string Id { get; set; }
        public RegisterResponseDto UserReviewer { get; set; }
        public string Comment { get; set; }
    }
}
