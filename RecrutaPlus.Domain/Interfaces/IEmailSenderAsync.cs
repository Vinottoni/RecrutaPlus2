using System.Threading.Tasks;

namespace RecrutaPlus.Domain.Interfaces
{
    public interface IEmailSenderAsync
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
