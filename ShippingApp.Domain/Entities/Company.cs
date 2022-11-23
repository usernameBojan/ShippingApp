namespace ShippingApp.Domain.Entities
{
    public class Company : IEntity
    {
        public Company() { }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ParcelLimitations? ParcelLimitations { get; set; }
        public IList<ParcelVolumeRange> ParcelVolumeRange { get; set; } = new List<ParcelVolumeRange>();
        public IList<ParcelWeightRange> ParcelWeightRange { get; set; } = new List<ParcelWeightRange>();
        public double CalculateCompanyShippingPriceForParcel(double volume, double weight)
        {
            double price;
            double volumePrice = 0;
            double weightPrice = 0;

            foreach (var range in ParcelVolumeRange)
            {
                if (range.HasMaxVolume && volume >= range.MinVolume && volume <= range.MaxVolume)
                {
                    volumePrice = range.Price;
                    break;
                }

                if (!range.HasMaxVolume && volume >= range.MinVolume)
                {
                    volumePrice = range.Price;
                    break;
                }
            }

            foreach (var range in ParcelWeightRange)
            {
                if(range.HasMaxWeight && weight >= range.MinWeight && weight <= range.MaxWeight)
                {
                    weightPrice = (double)(range.Price + ((weight - range.IncrementalPriceStartingPoint) * range.IncrementalPriceValue));
                    break;
                }

                if(!range.HasMaxWeight && weight >= range.MinWeight)
                {
                    weightPrice = (double)(range.Price + ((weight - range.IncrementalPriceStartingPoint) * range.IncrementalPriceValue));
                    break;
                }   
            }

            if(volume == 0 || weight == 0)
            {
                return -1;
            }

            if(weightPrice == 0 || volumePrice == 0)
            {
                return -1;
            }

            if (weightPrice >= volumePrice)
            {
                price = weightPrice;
            }
            else
            {
                price = volumePrice;
            }

            return price;
        }
    }
}