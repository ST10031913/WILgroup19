using Microsoft.AspNetCore.Mvc;
using ShadowOfHisWings.Models;
using System.Collections.Generic;

namespace ShadowOfHisWings.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            var services = new List<Service>
            {
                new Service
                {
                    Id = 1,
                    Title = "Programs",
                    Description = "Explore our structured programs that support recovery and spiritual growth."
                },
                new Service
                {
                    Id = 2,
                    Title = "Counsellors",
                    Description = "Meet our dedicated team of counsellors guiding individuals on their journey."
                },
                new Service
                {
                    Id = 3,
                    Title = "Outreach Programs",
                    Description = "Learn about our community outreach programs impacting lives."
                }
            };

            return View(services);
        }

        public IActionResult Programs()
        {
            ViewBag.Title = "Programs";
            return View();
        }

        public IActionResult Counsellors()
        {
            ViewBag.Title = "Counsellors";

            // Hardcoded counselor data
            var counsellors = new List<Counsellor>
            {
                new Counsellor
                {
                    Name = "Pastor Sergei Samuel Chetty and Pastor Jesse James",
                    Title = "Pastor",
                    Description = "Our role is to offer love and support, and being patient, expecting change as   we teach on the following subjects. (1) Biblical Principles. (2) Emotions: Can we trust them? Guilt, Anger etc. Interpretation of Impressions: Why you can't trust inner feelings. How to test feelings. (3) Suicide Prevention Awareness: Family Life. Short Term: Withdrawal, Aggression, Irritability, Rage. Long Term: Divorce, Social Isolation, Poor Relationships. (4) Counselling: Condemnation, Confidence, Depression, Positive Mind, Confessions, Suicidal Tendencies, well-Being etc. These lessons, from our observation and evaluation, do have a very positive impact. Our interaction, Q&A, helps us understand that we are making a huge difference. We thank Management for affording us the opportunity and trusting us.",
                   ImageUrl = "~/Counselors/pst segai-jessie.jpg"

                },
                new Counsellor
                {
                    Name = "Pastor Barney",
                    Title = "Pastor",
                    Description = "I am the resident Pastor of Shadow of HIS Wings Recovery Centre I see persons from all occupations and backgrounds who enrol for treatment against substance abuse. In my counselling with them I have established mental disorders, history of trauma and possible environmental and social influences that have attributed to substance addiction, as a counsellor, use one on one and group therapy sessions where patients are encouraged to talk about their issues. Families are also afforded the opportunity to be part of the patient's recovery process. Finally, the main aim of the recovery Centre is to assist the individual to re-enter their communities as sober, responsible and upstanding members of society.",
                    ImageUrl = "~/Counselors/pst barney.jpg"
                },
                new Counsellor
                {
                    Name = "Samuel Okoye",
                    Title = "Christian counsellor ",
                    Description = "It is common notice that our societies today are plagued by addiction and substance abuse. As many aspects of humanity collapses, people are searching for comfort. Unfortunately, many are taking to substance abuse and its destructive part. I started working with Shadow of His Wings in 2018.  Having come out of a life of addiction and drug dealing, there was a burning desire to help others break free from the shackles of drug abuse. This was when I met Rita and Matthew Abrahams, a couple with a similar vision and passion for broken people. At shadow of His Wings, we believe addiction is a spiritual enslavement that brings many spiritual and physical afflictions on the user and everyone around them. Our approach is not just to help the sufferer overcome their addiction but also to help them heal from the defects the lifestyle has brought to their personalities and life generally. This deep healing is only possible through detailed counselling and discipleship. ",
                    ImageUrl = "~/Counselors/pst samuel.jpg"
                }
            };

            return View(counsellors);
        }

        public IActionResult OutreachPrograms()
        {
            ViewBag.Title = "OutreachPrograms";
            return View();
        }
    }
}
