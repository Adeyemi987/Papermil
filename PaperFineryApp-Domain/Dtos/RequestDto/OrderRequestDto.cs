using Microsoft.AspNetCore.Http;
using PaperFineryApp_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFineryApp_Domain.Dtos.RequestDto
{
    public class OrderRequestDto
    {
        public TotalWeightInkg TotalWeightInKg { get; set; }
        public PaperTypes PaperTypes { get; set; }
        public DeliveryModes DeliveryMode { get; set; }
        public string? SupplierLocation { get; set; }
        public IEnumerable<IFormFile> ProductImages { get; set; }
    }
}