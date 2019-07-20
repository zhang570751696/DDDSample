using System.Threading.Tasks;

namespace RickWebApi.Infrastructure.Emails
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailMessage nessage);
    }
}
