using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShadowOfHisWings.Data;
using ShadowOfHisWings.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShadowOfHisWings.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        [AllowAnonymous]
        public IActionResult Index()
        {
            var events = _context.Events.ToList();
            return View(events);
        }

        // GET: Events/Manage
        [Authorize(Roles = "Admin")]
        public IActionResult Manage()
        {
            var events = _context.Events.ToList();
            return View(events);
        }

        // GET: Events/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Event evt)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(evt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Manage));
            }
            return View(evt);
        }

        // GET: Events/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var evt = await _context.Events.FindAsync(id);
            if (evt == null)
            {
                return NotFound();
            }
            return View(evt);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Event evt)
        {
            if (id != evt.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evt);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Manage));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Events.Any(e => e.Id == evt.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(evt);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem); // Returns the Delete confirmation view
        }

        // POST: Events/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            _context.Events.Remove(eventItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Manage)); // Redirect to the Manage view after deletion
        }
    }
}