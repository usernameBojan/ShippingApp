using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShippingApp.Application.Utilities;
using ShippingApp.Domain.Entities;

namespace ShippingApp.Infrastructure.EntityTypeConfigurations
{
    public class AdminTypeConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasData(new Admin(1, "Admin Adminsky", "adminxyz", Hasher.HashPassword("somerandompw"), true));
        }
    }
}