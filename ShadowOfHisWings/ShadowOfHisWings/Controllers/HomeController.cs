using Microsoft.AspNetCore.Mvc;
using ShadowOfHisWings.Data;
using ShadowOfHisWings.Models;
using System.Linq;

namespace ShadowOfHisWings.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Helper method to fetch latest images for events
        private List<Media> GetLatestEventImages(int count = 3)
        {
            return _context.Media
                .Where(m => m.Category == "Event")
                .OrderByDescending(m => m.DateUploaded) // Prefer DateUploaded over Id
                .Take(count)
                .ToList();
        }

        public ActionResult Index()
        {
            // Fetch latest event images
            var latestEventImages = GetLatestEventImages();

            // Set up the model for the home page
            var model = new Home
            {
                Title = "SHADOW OF HIS WINGS RECOVERY CENTRE",
                WelcomeMessage = "Your path to recovery starts here.",
                AboutInfo = @"At Shadow of His Wings Recovery Centre, our passion and expertise are dedicated to helping you, your loved ones, and the communities you belong to experience healthier, happier lives free from drug and alcohol addiction. We understand that addiction affects not only individuals but also families and the broader community. That’s why our comprehensive programs are designed to provide a supportive and nurturing environment for healing and empowerment.
                             We firmly believe that “Where there’s breath, there’s hope,” and this guiding principle drives our commitment to excellence in care. Our experienced team is here to support you every step of the way, addressing your physical, emotional, and psychological needs. From personalized counseling and group therapy to educational workshops and aftercare planning, we equip you with the tools necessary for long-term success and resilience.
                            By choosing Shadow of His Wings Recovery Centre, you are taking a crucial step towards transforming your life and embracing a brighter, addiction-free future.",
                LatestImages = latestEventImages // Add the images to the model
            };

            return View(model);
        }


        public ActionResult About()
        {
            var model = new Home
            {
                Title = "About Us",
                AboutInfo = "We are a Non-Profit organisation situated in the suburb of Chatsworth, Durban, South Africa. We are committed to eradicating drug and alcohol addiction that plague our communities, country and world at large. We provide holistic care to all our patients, focussing on their physical, emotional and spiritual well-being. We have a team of passionate and committed individuals who give off their time and expertise to assist our patients on their road to recovery.\r\n\r\nWithin our residential settings, individuals find not only effective treatment but also a supportive network of peers and Team Leaders who understand the unique challenges they face. From the 12 Step Program, group therapy sessions and individual counselling, we tailor our approach to meet the diverse needs of our community members."
            };
            return View(model);
        }
    }
}