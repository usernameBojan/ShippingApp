namespace ShippingApp.Domain.Entities
{
    public class ParcelWeightRange : IEntity
    {
        public ParcelWeightRange() { }
        public int Id { get; set; }
        public double MinWeight { get; set; }
        public bool HasMaxWeight { get; set; }
        public double MaxWeight { get; set; }
        public double Price { get; set; }
        public double IncrementalPriceStartingPoint { get; set; }
        public double IncrementalPriceValue { get; set; }
        public Company? Company { get; set; }
    }
}