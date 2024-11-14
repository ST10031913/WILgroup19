using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ShadowOfHisWings.Models;

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
            var smtpClient = new SmtpClient
            {
                Host = _configuration["Smtp:Server"],
                Port = int.Parse(_configuration["Smtp:Port"]),
                EnableSsl = bool.Parse(_configuration["Smtp:EnableSsl"]),
                Credentials = new NetworkCredential(
                    _configuration["Smtp:SenderEmail"],
                    _configuration["Smtp:SenderPassword"])
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["Smtp:SenderEmail"]),
                Subject = contact.Subject, // Use the subject from the contact form
                Body = $"Name: {contact.Name}\nEmail: {contact.Email}\nMessage: {contact.Message}",
                IsBodyHtml = false,
            };

            mailMessage.To.Add(_configuration["Smtp:RecipientEmail"]);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}