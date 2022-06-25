namespace UniversityHostel.Server.Services
{
    using RestSharp;
    using RestSharp.Authenticators;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using UniversityHostel.Shared.Services;

    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string body)
        {
            //string serverEmail = "dd1fb443c3aa9d";

            //var client = new SmtpClient("smtp.mailtrap.io", 2525)
            //{
            //    Credentials = new NetworkCredential("dd1fb443c3aa9d", "62533e2e17b3c5"),
            //    EnableSsl = true
            //};
            //var client = new SmtpClient("smtp.gmail.com", 587)
            //{
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(serverEmail, "AZJrcz8969TA6Ki"),
            //    EnableSsl = true
            //};




            RestClient client = new RestClient();
            client.Authenticator = new HttpBasicAuthenticator("api", "17cd42405646ee3d1208f9d0c152f3c0-4f207195-ba8b61ef");
            RestRequest request = new RestRequest();
            request.Resource = "https://api.mailgun.net/v3/{domain}/messages";
            request.AddParameter("domain", "sandboxea3478694598481cbb76330543d54eb9.mailgun.org", ParameterType.UrlSegment);
            request.AddParameter("from", "Mailgun Sandbox <postmaster@sandboxea3478694598481cbb76330543d54eb9.mailgun.org>");
            request.AddParameter("to", $"<{email}>");
            request.AddParameter("subject", subject);
            request.AddParameter("html", body);
            request.Method = Method.Post;
            await client.ExecuteAsync(request);

            //await client.SendMailAsync("piotr@mailtrap.io", email, subject, body);
        }
    }
}