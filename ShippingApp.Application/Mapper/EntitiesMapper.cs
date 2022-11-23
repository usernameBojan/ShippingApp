using AutoMapper;
using ShippingApp.Application.Dto.Admin;
using ShippingApp.Application.Dto.Company;
using ShippingApp.Application.Dto.Order;
using ShippingApp.Application.Dto.Parcel;
using ShippingApp.Domain.Entities;

namespace ShippingApp.Application.Mapper
{
    public static class EntitiesMapper
    {
        public static MapperConfiguration GetConfiguration()
        {
            return new(cfg =>
            {
                cfg.CreateMap<Admin, AdminDto>();

                cfg.CreateMap<AdminDto, Admin>()
                .ForMember(m => m.Password, m => m.Ignore());

                cfg.CreateMap<CreateAdminDto, Admin>()
                .ForMember(m => m.Password, m => m.Ignore());

                cfg.CreateMap<CreateAdminDto, AdminDto>();

                cfg.CreateMap<Company, CompanyDto>().ReverseMap();

                cfg.CreateMap<Company, CreateCompanyDto>().ReverseMap();

                cfg.CreateMap<CreateCompanyDto, CompanyDto>().ReverseMap();

                cfg.CreateMap<ParcelLimitations, ParcelLimitationsDto>().ReverseMap();

                cfg.CreateMap<ParcelLimitations, CreateParcelLimitationsDto>().ReverseMap();

                cfg.CreateMap<ParcelVolumeRange, ParcelVolumeRangeDto>().ReverseMap();

                cfg.CreateMap<ParcelWeightRange, ParcelWeightRangeDto>().ReverseMap();

                cfg.CreateMap<ParcelWeightRange, CreateParcelWeightRangeDto>().ReverseMap();

                cfg.CreateMap<ParcelVolumeRange, CreateParcelVolumeRangeDto>().ReverseMap();

                cfg.CreateMap<ParcelInquiryStatistics, ParcelInquiryStatisticsDto>().ReverseMap();

                cfg.CreateMap<Order, OrderDto>().ReverseMap();

                cfg.CreateMap<Order, CreateOrderDto>().ReverseMap();

                cfg.CreateMap<OrderDto, CreateOrderDto>().ReverseMap();
            });
        }
    }
}