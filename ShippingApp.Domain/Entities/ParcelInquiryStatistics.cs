namespace ShippingApp.Domain.Entities
{
    public class ParcelInquiryStatistics : IEntity
    {
        public ParcelInquiryStatistics() { }
        public ParcelInquiryStatistics(double weight, double height, double width, double length, double volume, double price)
        {
            Weight = weight;
            Height = height;
            Width = width;
            Length = length;
            Volume = volume;
            DateOfInquiry = DateTime.Now;
            Price = price;
        }
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Volume { get; set; }
        public double Price { get; set; }
        public DateTime DateOfInquiry { get; private set; }
    }
}