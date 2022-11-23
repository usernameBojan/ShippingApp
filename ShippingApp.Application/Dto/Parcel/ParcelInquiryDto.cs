using System.ComponentModel.DataAnnotations;

namespace ShippingApp.Application.Dto.Parcel
{
    public class ParcelInquiryDto
    {
        [Required]
        public double Weight { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Length { get; set; }
    }
}