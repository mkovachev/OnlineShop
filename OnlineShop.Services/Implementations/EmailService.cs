using MimeKit;
using MimeKit.Text;
using OnlineShop.Services.Interfaces;
using OnlineShop.Services.Models.EmailService;
using System.Linq;
using System.Net.Mail;

namespace OnlineShop.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            this.emailConfiguration = emailConfiguration;
        }

        public void SendEmail(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

            message.Subject = emailMessage.Subject;

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Content
            };

            using (var emailClient = new SmtpClient())
            {
                //// true uses SSL
                //emailClient.Connect(emailConfiguration.SmtpServer, emailConfiguration.SmtpPort, true);

                ////Remove any OAuth functionality
                //emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                //emailClient.Authenticate(emailConfiguration.SmtpUsername, emailConfiguration.SmtpPassword);

                //emailClient.Send(message);

                //emailClient.Disconnect(true);
            }
        }
    }
}
