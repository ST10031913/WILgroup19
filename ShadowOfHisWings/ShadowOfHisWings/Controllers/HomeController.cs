
using Microsoft.AspNetCore.Mvc;
using ShadowOfHisWings.Models;

namespace ShadowOfHisWings.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new Home
            {
                Title = "Welcome to Shadow of His Wings",
                WelcomeMessage = "Your path to recovery starts here.",
                AboutInfo = "Shadow of His Wings is a drug recovery center dedicated to helping individuals find their path to recovery."
            };
            return View(model);
        }

        public ActionResult About()
        {
            var model = new Home
            {
                Title = "About Us",
                AboutInfo = "Shadow of His Wings is a drug recovery center dedicated to helping individuals find their path to recovery."
            };
            return View(model);
        }
    }
}
