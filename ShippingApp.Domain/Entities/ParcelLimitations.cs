namespace ShippingApp.Domain.Entities
{
    public class ParcelLimitations : IEntity
    {
        public ParcelLimitations() { }
        public int Id { get; set; }
        public double MinWeight { get; set; }
        public double MaxWeight { get; set; }
        public double MinVolume { get; set; }
        public double MaxVolume { get; set; }
        public Company? Company { get; set; }
    }
}