using Microsoft.AspNetCore.Mvc;
using ShadowOfHisWings.Data;
using ShadowOfHisWings.Models;
using System.Threading.Tasks;

namespace ShadowOfHisWings.Controllers
{
    public class DonationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Donation
        public IActionResult Index()
        {
            return View();
        }

        // POST: Donation/Submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(Donation donation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donation);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Thank you for your donation!";
                return View("Index");
            }
            return View("Index", donation);
        }
    }
}
