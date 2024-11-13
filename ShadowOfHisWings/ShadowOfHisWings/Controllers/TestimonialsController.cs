using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShadowOfHisWings.Data;
using ShadowOfHisWings.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ShadowOfHisWings.Controllers
{
    public class TestimonialsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestimonialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Testimonials
        [AllowAnonymous]
        public IActionResult Index()
        {
            var testimonials = _context.Testimonials
                .Where(t => t.IsApproved)
                .OrderByDescending(t => t.DateCreated)
                .ToList();
            return View(testimonials);
        }

        // GET: Testimonials/Manage
        [Authorize(Roles = "Admin")]
        public IActionResult Manage()
        {
            var testimonials = _context.Testimonials
                .OrderByDescending(t => t.DateCreated)
                .ToList();
            return View(testimonials);
        }

        // GET: Testimonials/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Testimonials/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Testimonial testimonial)
        {
            if (ModelState.IsValid)
            {
                _context.Testimonials.Add(testimonial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Manage));
            }
            return View(testimonial);
        }

        // GET: Testimonials/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            return View(testimonial);
        }

        // POST: Testimonials/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, Testimonial testimonial)
        {
            if (id != testimonial.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Update(testimonial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Manage));
            }
            return View(testimonial);
        }

        // GET: Testimonials/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            return View(testimonial);
        }

        // POST: Testimonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial != null)
            {
                _context.Testimonials.Remove(testimonial);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Manage));
        }
    }
}
