using PaperFineryApp_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFineryApp_Domain.Dtos.ResponseDto
{
    public class OrderResponseDto
    {
        public string? Id { get; set; }
        public DateTime OrderInitializationTime { get; set; }
        public string? OrderReference { get; set; }
        public string TotalWeightInKgDesc { get; set; }
        public string PaperTypeDesc { get; set; }
        public string DeliveryModesDesc { get; set; }
        public string OrderStatusDesc { get; set; }
        public string? SupplierLocation { get; set; }
        public string? ProductImageUrls { get; set; } 
    }
}
