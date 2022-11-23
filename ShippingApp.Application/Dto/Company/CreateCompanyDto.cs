using ShippingApp.Application.Dto.Parcel;

namespace ShippingApp.Application.Dto.Company
{
    public class CreateCompanyDto
    {
        public string Name { get; set; } = string.Empty;
        public CreateParcelLimitationsDto? ParcelLimitations { get; set; }
        public IList<CreateParcelVolumeRangeDto> ParcelVolumeRange { get; set; } = new List<CreateParcelVolumeRangeDto>();
        public IList<CreateParcelWeightRangeDto> ParcelWeightRange { get; set; } = new List<CreateParcelWeightRangeDto>();
    }
}