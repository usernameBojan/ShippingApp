namespace ShippingApp.Domain.Entities
{
    public class Order : IEntity
    {
        public Order() { }
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerLastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public double Weight { get; set; }
        public double Volume { get; set; }
        public double Price { get; set; }
    }
}