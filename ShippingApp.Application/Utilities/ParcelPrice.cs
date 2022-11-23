using ShippingApp.Application.Repository;
using ShippingApp.Domain.Entities;

namespace ShippingApp.Application.Utilities
{
    internal static class ParcelPrice
    {
        internal static double CalculateParcelPrice(this IRepository<Company> repository, double volume, double weight)
        {
            double price;
            List<double> prices = new();

            price = repository.Query().FirstOrDefault()!.CalculateCompanyShippingPriceForParcel(volume, weight);

            if(price != -1)
            {
                prices.Add(price);
            }
            else
            {
                prices = repository.Query().Select(c => c.CalculateCompanyShippingPriceForParcel(volume, weight)).ToList();
            }

            return !prices.Where(x => x != -1).Any() ? 0 : prices.Where(x => x != -1).Min();
        }
    }
}