using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShippingApp.Domain.Entities;

namespace ShippingApp.Infrastructure.EntityTypeConfigurations
{
    public class CompanyTypeConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(new Company()
            {
                Id = 1,
                Name = "Cargo4You"
            });

            builder.HasData(new Company()
            {
                Id = 2,
                Name = "ShipFaster"
            }); 

            builder.HasData(new Company()
            {
                Id = 3,
                Name = "MaltaShip"
            });

            builder.OwnsOne(e => e.ParcelLimitations).HasData(new
            {
                Id = 1,
                CompanyId = 1,
                MinVolume = 0.0,
                MaxVolume = 2000.0,
                MinWeight = 0.0,
                MaxWeight = 20.0
            });

            builder.OwnsOne(e => e.ParcelLimitations).HasData(new
            {
                Id = 2,
                CompanyId = 2,
                MinVolume = 0.0,
                MaxVolume = 1700.0,
                MinWeight = 10.0,
                MaxWeight = 30.0
            });

            builder.OwnsOne(e => e.ParcelLimitations).HasData(new
            {
                Id = 3,
                CompanyId = 3,
                MinVolume = 500.0,
                MaxVolume = 0.0,
                MinWeight = 10.0,
                MaxWeight = 0.0,
            });

            builder.OwnsMany(e => e.ParcelVolumeRange).HasData(
                new
                {
                    Id = 1,
                    CompanyId = 1,
                    MinVolume = 0.0,
                    MaxVolume = 1000.0,
                    Price = 10.0,
                    HasMaxVolume = true
                },
                new
                {
                    Id = 2,
                    CompanyId = 1,
                    MinVolume = 1000.0,
                    MaxVolume = 2000.0,
                    Price = 20.0,
                    HasMaxVolume = true
                },
                new
                {
                    Id = 3,
                    CompanyId = 2,
                    MinVolume = 0.0,
                    MaxVolume = 1000.0,
                    Price = 11.99,
                    HasMaxVolume = true
                },
                new
                {
                    Id = 4,
                    CompanyId = 2,
                    MinVolume = 1000.0,
                    MaxVolume = 1700.0,
                    Price = 21.99,
                    HasMaxVolume = true
                },
                new
                {
                    Id = 5,
                    CompanyId = 3,
                    MinVolume = 500.0,
                    MaxVolume = 1000.0,
                    Price = 9.5,
                    HasMaxVolume = true
                },
                new
                {
                    Id = 6,
                    CompanyId = 3,
                    MinVolume = 1000.0,
                    MaxVolume = 2000.0,
                    Price = 19.5,
                    HasMaxVolume = true
                },
                new
                {
                    Id = 7,
                    CompanyId = 3,
                    MinVolume = 2000.0,
                    MaxVolume = 5000.0,
                    Price = 48.50,
                    HasMaxVolume = true
                },
                new
                {
                    Id = 8,
                    CompanyId = 3,
                    MinVolume = 5000.0,
                    MaxVolume = 0.0,
                    Price = 147.50,
                    HasMaxVolume = false
                });

            builder.OwnsMany(e => e.ParcelWeightRange).HasData(
                new
                {
                    Id = 1,
                    CompanyId = 1,
                    MinWeight = 0.0,
                    MaxWeight = 2.0,
                    Price = 15.0,
                    HasMaxWeight = true,
                    IncrementalPriceStartingPoint = 0.0,
                    IncrementalPriceValue = 0.0,
                },
                new
                {
                    Id = 2,
                    CompanyId = 1,
                    MinWeight = 2.0,
                    MaxWeight = 15.0,
                    Price = 18.0,
                    HasMaxWeight = true,
                    IncrementalPriceStartingPoint = 0.0,
                    IncrementalPriceValue = 0.0,
                },
                new
                {
                    Id = 3,
                    CompanyId = 1,
                    MinWeight = 15.0,
                    MaxWeight = 20.0,
                    Price = 35.0,
                    HasMaxWeight = true,
                    IncrementalPriceStartingPoint = 0.0,
                    IncrementalPriceValue = 0.0,
                },
                new
                {
                    Id = 4,
                    CompanyId = 2,
                    MinWeight = 10.0,
                    MaxWeight = 15.0,
                    Price = 16.50,
                    HasMaxWeight = true,
                    IncrementalPriceStartingPoint = 0.0,
                    IncrementalPriceValue = 0.0,
                },
                new
                {
                    Id = 5,
                    CompanyId = 2,
                    MinWeight = 15.0,
                    MaxWeight = 25.0,
                    Price = 36.50,
                    HasMaxWeight = true,
                    IncrementalPriceStartingPoint = 0.0,
                    IncrementalPriceValue = 0.0,
                },
                new
                {
                    Id = 6,
                    CompanyId = 2,
                    MinWeight = 25.0,
                    MaxWeight = 30.0,
                    Price = 40.0,
                    HasMaxWeight = true,
                    IncrementalPriceStartingPoint = 25.0,
                    IncrementalPriceValue = 0.417,
                },
                new
                {
                    Id = 7,
                    CompanyId = 3,
                    MinWeight = 10.0,
                    MaxWeight = 20.0,
                    Price = 16.99,
                    HasMaxWeight = true,
                    IncrementalPriceStartingPoint = 0.0,
                    IncrementalPriceValue = 0.0,
                },
                new
                {
                    Id = 8,
                    CompanyId = 3,
                    MinWeight = 20.0,
                    MaxWeight = 30.0,
                    Price = 33.99,
                    HasMaxWeight = true,
                    IncrementalPriceStartingPoint = 0.0,
                    IncrementalPriceValue = 0.0,
                },
                new
                {
                    Id = 9,
                    CompanyId = 3,
                    MinWeight = 30.0,
                    MaxWeight = 0.0,
                    Price = 43.99,
                    HasMaxWeight = false,
                    IncrementalPriceStartingPoint = 25.0,
                    IncrementalPriceValue = 0.41,
                });
        }
    }
}