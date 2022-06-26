namespace UniversityHostel.Server.Services
{
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Threading.Tasks;
    using UniversityHostel.Shared.Services;

    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string body)
        {
            string serverEmail = "universityhostel@hotmail.com";

            var client = new SmtpClient("smtp.office365.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(serverEmail, Encoding.UTF8.GetString(Convert.FromBase64String("X1RrbzZYUSpLLkwmfSh8Rw=="))),
                EnableSsl = true
            };

            var mail = new MailMessage();
            mail.From = new MailAddress(serverEmail);
            mail.To.Add(email);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body;

            await client.SendMailAsync(mail);
        }
    }
}