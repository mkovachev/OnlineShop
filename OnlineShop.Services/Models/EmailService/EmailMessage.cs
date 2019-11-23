using System.Collections.Generic;

namespace OnlineShop.Services.Models.EmailService
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            ToAddresses = new List<EmailAddress>();
            FromAddresses = new List<EmailAddress>();
        }

        public ICollection<EmailAddress> ToAddresses { get; set; } = new List<EmailAddress>();
        public ICollection<EmailAddress> FromAddresses { get; set; } = new List<EmailAddress>();
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
