namespace ShippingApp.Application.Dto.Parcel
{
    public class ParcelInquiryStatisticsDto : ParcelInquiryDto
    {
        public double Volume { get; set; }
        public double Price { get; set; }
        public DateTime DateOfInquiry { get; set; }
    }
}