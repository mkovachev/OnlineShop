using OnlineShop.Services.Models.EmailService;

namespace OnlineShop.Services.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(EmailMessage emailMessage);
    }
}
