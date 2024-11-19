using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShadowOfHisWings.Models;

namespace ShadowOfHisWings.Controllers
{
    public class EventsController : Controller
    {
        // Display the list of events (accessible to everyone)
        public ActionResult Index()
        {
            var events = new List<Event>
            {
                new Event { Title = "Event 1", Description = "Description 1", Location = "Location 1", Date = DateTime.Now },
                new Event { Title = "Event 2", Description = "Description 2", Location = "Location 2", Date = DateTime.Now.AddDays(1) }
            };
            return View(events);
        }

        // Add event - restricted to Admins
        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public ActionResult AddEvent()
        {
            return View();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public ActionResult AddEvent(Event model)
        {
            if (ModelState.IsValid)
            {
                // Code to add event to database
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Edit event - restricted to Admins
        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            // Code to fetch event from database using the id
            var eventToEdit = new Event { Title = "Event 1", Description = "Description 1", Location = "Location 1", Date = DateTime.Now };
            return View(eventToEdit);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public ActionResult EditEvent(Event model)
        {
            if (ModelState.IsValid)
            {
                // Code to update event in database
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Delete event - restricted to Admins
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public ActionResult DeleteEvent(int id)
        {
            // Code to delete the event from the database using the id
            return RedirectToAction("Index");
        }
    }
}
