using AutoMapper;
using ShippingApp.Application.Dto.Order;
using ShippingApp.Application.Dto.Parcel;
using ShippingApp.Application.Repository;
using ShippingApp.Application.Utilities;
using ShippingApp.Domain.Entities;

namespace ShippingApp.Application.Services.Implementation
{
    public class ParcelService : IParcelService
    {
        private readonly IRepository<Company> companyRepository;
        private readonly IRepository<ParcelInquiryStatistics> statisticsRepository;
        private readonly IRepository<Order> orderRepository;
        private readonly IEmailSender emailSender;
        private readonly IMapper mapper;
        public ParcelService(
            IRepository<Company> companyRepository, 
            IRepository<ParcelInquiryStatistics> statisticsRepository,
            IRepository<Order> orderRepository,
            IEmailSender emailSender,
            IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.statisticsRepository = statisticsRepository;
            this.mapper = mapper;
            this.emailSender = emailSender;
            this.orderRepository = orderRepository;
        }

        public ParcelPriceDto CalculateParcelPrice(ParcelInquiryDto parcelDetails)
        {
            double price;
            var weight = parcelDetails.Weight;
            var volume = Volume.Calc(parcelDetails.Height, parcelDetails.Width, parcelDetails.Length);

            price = companyRepository.CalculateParcelPrice(volume, weight);

            if(price == 0)
            {
                throw new Exception("Currently we are unable to deliever a package with the provided parameters.");
            }

            var inquiry = statisticsRepository.Create(new(
                weight, parcelDetails.Height, parcelDetails.Width, parcelDetails.Length, volume, price)
                );

            return new()
            {
                Price = price,
                InquiryId = inquiry.Id
            };
        }
        public ParcelInquiryStatisticsDto GetParcelInquiry(int id)
        {
            return mapper.Map<ParcelInquiryStatisticsDto>(statisticsRepository.GetById(id));
        }
        public IEnumerable<ParcelInquiryStatisticsDto> GetParcelInquiryStatistics()
        {
            return statisticsRepository.Query().Select(x => mapper.Map<ParcelInquiryStatisticsDto>(x)).ToList();
        }
        public IEnumerable<OrderDto> GetOrders()
        {
            return orderRepository.Query().Select(o => mapper.Map<OrderDto>(o));
        }
        public OrderDto CreateOrder(CreateOrderDto createOrderDto)
        {
            var volume = Volume.Calc(createOrderDto.Height, createOrderDto.Width, createOrderDto.Length);
            var weight = createOrderDto.Weight;

            var order = mapper.Map<Order>(createOrderDto);

            order.Volume = volume;
            order.Price = companyRepository.CalculateParcelPrice(volume, weight);
            
            if(order.Price == 0)
            {
                throw new Exception("Currently we are unable to deliever a package with the provided parameters.");
            }

            orderRepository.Create(order);

            emailSender.SendEmail(
                EmailContents.OrderInvoiceSubject, 
                EmailContents.OrderInvoiceBody(order.CustomerName, order.CustomerLastName, order.ShippingAddress), 
                order.Email
                );

            return mapper.Map<OrderDto>(order);
        }
        public void DeleteOrder(int id)
        {
            var order = orderRepository.GetById(id) ?? throw new Exception("Not Found");

            orderRepository.Delete(order);
        }
    }
}