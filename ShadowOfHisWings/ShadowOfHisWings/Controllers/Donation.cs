using Microsoft.AspNetCore.Mvc;
using ShadowOfHisWings.Models;

namespace ShadowOfHisWings.Controllers
{
    public class DonationController : Controller
    {
        public ActionResult Index()
        {
            var model = new Donation();
            return View(model);
        }

        [HttpPost]
        public ActionResult Submit(Donation model)
        {
            if (ModelState.IsValid)
            {
               

                ViewBag.Message = "Thank you for your donation!";
                return View("Index", new Donation());
            }

            return View("Index", model);
        }
    }
}
