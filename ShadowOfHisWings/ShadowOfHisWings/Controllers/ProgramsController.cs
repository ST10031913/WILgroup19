using Microsoft.AspNetCore.Mvc;
using ShadowOfHisWings.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShadowOfHisWings.Controllers
{
    public class ProgramsController : Controller
    {
        // Sample data
        private List<ServiceProgram> programs = new List<ServiceProgram>
        {
            new ServiceProgram { Id = 1, Title = "Recovery Support", ShortDescription = "Personalized support programs...", FullDescription = "Detailed information about Recovery Support." },
            new ServiceProgram { Id = 2, Title = "Counseling Services", ShortDescription = "Professional counselors providing...", FullDescription = "Detailed information about Counseling Services." },
            new ServiceProgram { Id = 3, Title = "Community Outreach", ShortDescription = "Engaging with the community...", FullDescription = "Detailed information about Community Outreach." }
        };

        public IActionResult Index()
        {
            return View(programs);
        }

        public IActionResult Details(int id)
        {
            var program = programs.FirstOrDefault(p => p.Id == id);
            if (program == null)
            {
                return NotFound();
            }
            return View(program);
        }
    }
}
