using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShadowOfHisWings.Models;

namespace ShadowOfHisWings.Controllers
{
    public class EventsController : Controller
    {
        public ActionResult Index()
        {
            var events = new List<Event>
            {
                new Event { Title = "Event 1", Description = "Description 1", Location = "Location 1", Date = DateTime.Now },
                new Event { Title = "Event 2", Description = "Description 2", Location = "Location 2", Date = DateTime.Now.AddDays(1) }
            };
            return View(events);
        }
    }
}
