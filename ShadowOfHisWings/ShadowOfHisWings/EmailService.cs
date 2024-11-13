// Services/EmailService.cs
using Microsoft.Extensions.Configuration;
using ShadowOfHisWings.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ShadowOfHisWings.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendContactEmailAsync(Contact contact)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");

            var smtpHost = emailSettings.GetValue<string>("SmtpHost");
            var smtpPort = emailSettings.GetValue<int>("SmtpPort");
            var smtpUser = emailSettings.GetValue<string>("SmtpUser");
            var smtpPass = emailSettings.GetValue<string>("SmtpPass");
            var fromEmail = emailSettings.GetValue<string>("FromEmail");
            var toEmail = emailSettings.GetValue<string>("ToEmail");

            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = contact.Subject ?? "New Contact Us Message",
                Body = $"<p><strong>Name:</strong> {contact.Name}</p>" +
                       $"<p><strong>Email:</strong> {contact.Email}</p>" +
                       $"<p><strong>Message:</strong> {contact.Message}</p>",
                IsBodyHtml = true
            };

            mailMessage.To.Add(new MailAddress(toEmail));

            using (var smtpClient = new SmtpClient(smtpHost, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPass);
                smtpClient.EnableSsl = false; 
                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
