
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
                Title = "SHADOW OF HIS WINGS RECOVERY CENTRE",
                WelcomeMessage = "Your path to recovery starts here.",
                AboutInfo = "Welcome to Shadow of His Wings Recovery Centre, a Christian rehabilitation center dedicated to guiding individuals on their journey to recovery through the power of faith and the teachings of Christ.\r\n\r\nAt Shadow of His Wings, we believe that true healing comes from the heart and soul. Our mission is to provide a supportive and compassionate environment where each person can find their path to recovery, rooted in the transformative love of Jesus Christ.\r\n\r\nOur program is designed to address not only the physical aspects of addiction but also the emotional and spiritual dimensions. Through biblical counseling, prayer, and a strong community of faith, we help individuals rebuild their lives and restore their sense of purpose.\r\n\r\nWe are committed to offering more than just treatment; we aim to inspire a profound spiritual renewal. Our dedicated staff, all of whom share a deep commitment to Christian values, work tirelessly to support each individual’s journey towards a fulfilling, Christ-centered life.\r\n\r\nJoin us at Shadow of His Wings, where faith meets recovery, and let us walk with you towards healing and hope."
            };
            return View(model);
        }

        public ActionResult About()
        {
            var model = new Home
            {
                Title = "About Us",
                AboutInfo = "Welcome to Shadow of His Wings Recovery Centre, a Christian rehabilitation center dedicated to guiding individuals on their journey to recovery through the power of faith and the teachings of Christ.\r\n\r\nAt Shadow of His Wings, we believe that true healing comes from the heart and soul. Our mission is to provide a supportive and compassionate environment where each person can find their path to recovery, rooted in the transformative love of Jesus Christ.\r\n\r\nOur program is designed to address not only the physical aspects of addiction but also the emotional and spiritual dimensions. Through biblical counseling, prayer, and a strong community of faith, we help individuals rebuild their lives and restore their sense of purpose.\r\n\r\nWe are committed to offering more than just treatment; we aim to inspire a profound spiritual renewal. Our dedicated staff, all of whom share a deep commitment to Christian values, work tirelessly to support each individual’s journey towards a fulfilling, Christ-centered life.\r\n\r\nJoin us at Shadow of His Wings, where faith meets recovery, and let us walk with you towards healing and hope."
            };
            return View(model);
        }
    }
}
