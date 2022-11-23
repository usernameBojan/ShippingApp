using Microsoft.EntityFrameworkCore;
using ShippingApp.Domain.Entities;

namespace ShippingApp.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ParcelInquiryStatistics> Statistics { get; set; }
        public DbSet<ParcelLimitations> Limitations { get; set; }
        public DbSet<ParcelVolumeRange> VolumeRanges { get; set; }
        public DbSet<ParcelWeightRange> WeightRanges { get; set; }
    }
}