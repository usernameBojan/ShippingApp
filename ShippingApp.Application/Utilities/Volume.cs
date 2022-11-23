namespace ShippingApp.Application.Utilities
{
    internal static class Volume
    {
        internal static double Calc(double height, double width, double length)
        {
            return height * width * length;
        }
    }
}