using System.ComponentModel.DataAnnotations;

namespace ShippingApp.Application.Dto.Order
{
    public class OrderDto 
    {
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerLastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public double Volume { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
    }
}