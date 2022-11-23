namespace ShippingApp.Application.Dto.Parcel
{
    public class CreateParcelWeightRangeDto : ParcelWeightRangeDto
    {
        public bool HasIncrementalPrice { get; set; }
    }
}