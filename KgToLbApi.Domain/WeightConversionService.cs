namespace KgToLbApi.Domain   
{
    public class WeightConversionService
    {
        private const double KgToPoundsFactor = 2.20462;

        public double ConvertKgToPounds(double kilograms)
        {
            if (kilograms < 0)
                throw new ArgumentException("Kilograms must be positive.");

            return kilograms * KgToPoundsFactor;
        }
    }
}
