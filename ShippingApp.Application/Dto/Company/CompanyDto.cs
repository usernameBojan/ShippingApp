using ShippingApp.Application.Dto.Parcel;
using System.ComponentModel.DataAnnotations;

namespace ShippingApp.Application.Dto.Company
{
    public class CompanyDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public ParcelLimitationsDto? ParcelLimitations { get; set; }
        public IList<ParcelVolumeRangeDto> ParcelVolumeRange { get; set; } = new List<ParcelVolumeRangeDto>();
        public IList<ParcelWeightRangeDto> ParcelWeightRange { get; set; } = new List<ParcelWeightRangeDto>();
    }
}