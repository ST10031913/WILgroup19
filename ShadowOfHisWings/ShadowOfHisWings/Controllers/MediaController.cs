using Microsoft.AspNetCore.Mvc;

namespace ShadowOfHisWings.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Videos()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }
    }
}
