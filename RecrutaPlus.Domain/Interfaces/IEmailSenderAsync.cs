using System.Threading.Tasks;

namespace Safety.Domain.Interfaces
{
    public interface IEmailSenderAsync
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
