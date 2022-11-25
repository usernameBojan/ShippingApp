namespace ShippingApp.Application.Dto.Parcel
{
    public class ParcelLimitationsDto
    {
        public double MinVolume { get; set; }
        public double MaxVolume { get; set; }
        public double MinWeight { get; set; }
        public double MaxWeight { get; set; }
        public bool HasMaxVolume => MaxVolume > 0;
        public bool HasMaxWeight => MaxWeight > 0;
    }
}