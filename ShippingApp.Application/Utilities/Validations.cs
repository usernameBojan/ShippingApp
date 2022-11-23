using ShippingApp.Application.Dto.Company;

namespace ShippingApp.Application.Utilities
{
    internal static class Validations
    {
        private const string MaxValExMsg = "Maximum value of the highest range must be same as the provided maximum value.";
        private const string UnequalValsExMsg = "Minimal value of the range must be same as maximum value of the previous range.";

        internal static void ValidateRangeValues(this CreateCompanyDto dto)
        {
            for (int i = dto.ParcelVolumeRange.Count - 1; i >= 1; i--)
            {
                if (dto.ParcelVolumeRange[i].MinVolume != dto.ParcelVolumeRange[i - 1].MaxVolume)
                {
                    throw new Exception(UnequalValsExMsg);
                }
            }

            for (int i = dto.ParcelWeightRange.Count - 1; i >= 1; i--)
            {
                if (dto.ParcelWeightRange[i].MinWeight != dto.ParcelWeightRange[i - 1].MaxWeight)
                {
                    throw new Exception(UnequalValsExMsg);
                }
            }

            if (dto.ParcelLimitations!.HasMaxVolume && dto.ParcelLimitations.MaxVolume != dto.ParcelVolumeRange[dto.ParcelVolumeRange.Count - 1].MaxVolume)
            {
                throw new Exception(MaxValExMsg);
            }

            if (dto.ParcelLimitations!.HasMaxWeight && dto.ParcelLimitations.MaxWeight != dto.ParcelWeightRange[dto.ParcelWeightRange.Count - 1].MaxWeight)
            {
                throw new Exception(MaxValExMsg);
            }
        }
    }
}