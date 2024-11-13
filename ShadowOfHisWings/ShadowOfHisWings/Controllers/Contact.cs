// Controllers/ContactController.cs
using Microsoft.AspNetCore.Mvc;
using ShadowOfHisWings.Data;
using ShadowOfHisWings.Models;
using ShadowOfHisWings.Services;
using System.Threading.Tasks;

namespace ShadowOfHisWings.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public ContactController(ApplicationDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // GET: Contact
        public IActionResult Index()
        {
            return View();
        }

        // POST: Contact/Submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();

                // Send email
                await _emailService.SendContactEmailAsync(contact);

                TempData["Message"] = "Your message has been sent.";
                return RedirectToAction("Index");
            }
            return View("Index", contact);
        }
    }
}
