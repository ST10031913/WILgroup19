using System;
using ShadowOfHisWings.Models;
using Microsoft.AspNetCore.Mvc;

namespace ShadowOfHisWings.Controllers
{
    public class ContactController : Controller
    {

        public IActionResult Index()
        {
            var model = new Contact();
            return View(model);
        }
       

    }
}
