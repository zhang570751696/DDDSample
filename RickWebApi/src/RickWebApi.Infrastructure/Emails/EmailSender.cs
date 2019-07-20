using System.Threading.Tasks;

namespace RickWebApi.Infrastructure.Emails
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(EmailMessage nessage)
        {
            // Integration with email service.

            return;
        }
    }
}
