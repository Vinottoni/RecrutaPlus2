namespace Safety.Domain.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(string email, string subject, string message);
    }
}
