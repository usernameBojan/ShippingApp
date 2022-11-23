namespace ShippingApp.Domain.Entities
{
    public class ParcelVolumeRange : IEntity
    {
        public ParcelVolumeRange() { }
        public int Id { get; set; }
        public double MinVolume { get; set; }
        public bool HasMaxVolume { get; set; }
        public double MaxVolume { get; set; }
        public double Price { get; set; }
        public Company? Company { get; set; }
    }
}