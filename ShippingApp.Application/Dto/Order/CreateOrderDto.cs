using ShippingApp.Application.Dto.Parcel;
using System.ComponentModel.DataAnnotations;

namespace ShippingApp.Application.Dto.Order
{
    public class CreateOrderDto : ParcelInquiryDto
    {
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        public string CustomerLastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PickupAddress { get; set; } = string.Empty;
        [Required]
        public string ShippingAddress { get; set; } = string.Empty;
    }
}