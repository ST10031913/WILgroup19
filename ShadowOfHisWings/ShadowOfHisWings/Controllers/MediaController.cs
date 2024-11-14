using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShadowOfHisWings.Data;
using ShadowOfHisWings.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShadowOfHisWings.Controllers
{
    public class MediaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MediaController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage()
        {
            var mediaItems = _context.Media.ToList();
            return View(mediaItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Media media, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (media.Type == "Image" && ImageFile != null)
                {
                    // Process image upload
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(fileStream);
                    }
                    media.ImagePath = "/images/" + uniqueFileName;
                }
                else if (media.Type == "Video" && string.IsNullOrWhiteSpace(media.Url))
                {
                    ModelState.AddModelError("", "Please provide a valid URL for videos.");
                    return View(media);
                }

                _context.Add(media);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Manage));
            }
            return View(media);
        }

        // GET: Media/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var media = await _context.Media.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }
            return View(media);
        }

        // POST: Media/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Media media, IFormFile ImageFile)
        {
            if (id != media.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingMedia = await _context.Media.FindAsync(id);
                if (existingMedia == null)
                {
                    return NotFound();
                }

                existingMedia.Title = media.Title;
                existingMedia.Type = media.Type;
                existingMedia.Url = media.Type == "Video" ? media.Url : null;

                if (media.Type == "Image" && ImageFile != null)
                {
                    // Delete old image if there is one
                    if (!string.IsNullOrEmpty(existingMedia.ImagePath))
                    {
                        string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, existingMedia.ImagePath.TrimStart('/'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Upload new image
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(fileStream);
                    }
                    existingMedia.ImagePath = "/images/" + uniqueFileName;
                }

                _context.Update(existingMedia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Manage));
            }
            return View(media);
        }

        // POST: Media/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var media = await _context.Media.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }

            if (media.Type == "Image" && !string.IsNullOrEmpty(media.ImagePath))
            {
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, media.ImagePath.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _context.Media.Remove(media);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Manage));
        }

        public IActionResult Videos()
        {
            var videos = _context.Media.Where(m => m.Type == "Video").ToList();
            return View(videos);
        }

        public IActionResult Gallery()
        {
            var images = _context.Media.Where(m => m.Type == "Image").ToList();
            return View(images);
        }
    }
}
