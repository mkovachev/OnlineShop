using OnlineShop.Services.Interfaces;
using System.Threading.Tasks;

namespace OnlineShop.Services.Models.EmailService
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}
