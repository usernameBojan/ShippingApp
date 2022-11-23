using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingApp.Application.Dto.Parcel
{
    public class ParcelWeightRangeDto
    {
        public double MinWeight { get; set; }
        public double MaxWeight { get; set; }
        public double Price { get; set; }
        public double IncrementalPriceStartingPoint { get; set; }
        public double IncrementalPriceValue { get; set; }
    }
}
