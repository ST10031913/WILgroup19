using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using ShadowOfHisWings.Models;

namespace ShadowOfHisWings.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            var model = new Contact();
            return View(model);
        }

        [HttpPost]
        public ActionResult Submit(Contact model)
        {
            if (ModelState.IsValid)
            {
                SendEmail(model);
                ViewBag.Message = "Your message has been sent. Thank you!";
                return View("Index", new Contact());
            }
            return View("Index", model);
        }

        private void SendEmail(Contact model)
        {
            try
            {
                var fromAddress = new MailAddress("wilgroup19@gmail.com", "Shadow of His Wings");
                var toAddress = new MailAddress("wilgroup19@gmail.com", "Raffle Email");
                const string fromPassword = "WiLgr0up19SSHTL"; // replace with your email password
                string subject = "New Contact Form Submission";
                string body = $"Name: {model.Name}\nSurname: {model.Surname}\nEmail: {model.Email}\nComment: {model.Comment}";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (SmtpException ex)
            {
                // Log the exception details to debug
                System.Diagnostics.Debug.WriteLine("SMTP Exception: " + ex.Message);
                System.Diagnostics.Debug.WriteLine("Status Code: " + ex.StatusCode);
                System.Diagnostics.Debug.WriteLine("Stack Trace: " + ex.StackTrace);

                // Optionally, rethrow the exception or handle it as needed
                throw;
            }
            catch (Exception ex)
            {
                // Log other exceptions
                System.Diagnostics.Debug.WriteLine("General Exception: " + ex.Message);
                System.Diagnostics.Debug.WriteLine("Stack Trace: " + ex.StackTrace);

                // Optionally, rethrow the exception or handle it as needed
                throw;
            }
        }
    }
}