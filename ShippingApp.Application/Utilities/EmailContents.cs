namespace ShippingApp.Application.Utilities
{
    internal static class EmailContents
    {
        private const string companyName = "Cargo4You";
        internal const string OrderInvoiceSubject = $"{companyName} Order Invoice";

        internal static string OrderInvoiceBody(string name, string surname, string address)
        {
            return $"<p>Hello {name} {surname}. Thank you for using {companyName} shipping services.</p>" +
                "<p>Your order has been registered</p>" +
                $"<p>You will be notified when the package will arrive at {address} and for any other developements." +
                "<p>Don't hesitate to contact us for any information and don't hesitate to use our services again." +
                $"<p><i>{companyName}</i></p>";
        }
    }
}