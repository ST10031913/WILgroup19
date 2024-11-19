using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using ShadowOfHisWings.Models;

namespace ShadowOfHisWings.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            var model = new Contact();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(Contact model)
        {
            if (ModelState.IsValid)
            {

                await SendEmailAsync(model);
                // Display a success message to the user
                ViewBag.Message = "Your message has been sent successfully.";
                return View("Index", new Contact());
            }

            // If the model state is not valid, return the same view with errors
            return View("Index", model);
        }

        private async Task SendEmailAsync(Contact model)
        {
            try
            {
                // Define the email addresses and message content
                var fromAddress = "noreply@shadowofhiswings.co.za";
                var toAddress = "wilgroup19@gmail.com";
                var emailPassword = "WiLgr0up19SSHTL";

                var subject = "New Contact Form Submission";
                var body = $@"
                    <h3>New Contact Form Submission</h3>
                    <p><strong>Name:</strong> {model.Name}</p>
                    <p><strong>Surname:</strong> {model.Surname}</p>
                    <p><strong>Email:</strong> {model.Email}</p>
                    <p><strong>Comment:</strong></p>
                    <p>{model.Comment}</p>
                ";

                // Create the email message using MimeKit
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress("noreply@shadowofhiswings.co.za", fromAddress));
                mimeMessage.To.Add(new MailboxAddress("wilgroup19@gmail.com", toAddress));
                mimeMessage.Subject = subject;

                // Set the message body as HTML
                var bodyBuilder = new BodyBuilder { HtmlBody = body };
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                // Send the email using MailKit and SMTP
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(fromAddress, emailPassword);
                    await client.SendAsync(mimeMessage);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error appropriately
                Console.WriteLine("Error sending email: " + ex.Message);
                throw;
            }
        }
    }
}