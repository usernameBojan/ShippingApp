namespace ShippingApp.Application.Dto.Parcel
{
    public class CreateParcelLimitationsDto : ParcelLimitationsDto
    {
        public bool HasMaxVolume { get; set; }
        public bool HasMaxWeight { get; set; }
    }
}