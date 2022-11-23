using ShippingApp.Application.Dto.Order;
using ShippingApp.Application.Dto.Parcel;

namespace ShippingApp.Application.Services
{
    public interface IParcelService
    {
        ParcelPriceDto CalculateParcelPrice(ParcelInquiryDto parcelDetails);
        ParcelInquiryStatisticsDto GetParcelInquiry(int id);
        IEnumerable<ParcelInquiryStatisticsDto> GetParcelInquiryStatistics();
        IEnumerable<OrderDto> GetOrders();
        OrderDto CreateOrder(CreateOrderDto order);
        void DeleteOrder(int id);
    }
}