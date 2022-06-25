namespace UniversityHostel.Shared.Services
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string email, string subject, string body);
    }
}