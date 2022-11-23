namespace ShippingApp.Application.Services
{
    public interface IEmailSender
    {
        void SendEmail(string subject, string body, string recieverEmailAddress);
    }
}