using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelTripCoreProject.Business.Services;
using TravelTripCoreProject.DataAccessLayer.Contexts;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.Controllers
{
    public class MainController(IBlogService blogService, IContactService contactService, IAboutService aboutService) : Controller
    {
        private readonly IBlogService _blogService = blogService;
        private readonly IContactService _contactService = contactService;
        private readonly IAboutService _aboutService = aboutService;

        public IActionResult Index()
        {
            var values = _blogService.GetAllBlogs().Take(6).ToList();

            return View(values);
        }
        public IActionResult About()
        {
            var values = _aboutService.GetAll();
            return View(values);
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(string name, string email, string message, string subject)
        {
            var result = _contactService.AddContact(new Contact
            {
                NameSurname = name,
                Email = email,
                Message = message,
                Subject = subject
            });
            ViewBag.Message = result ? "Mesajınız alındı!" : "Bir hata oluştu.";
            return View();
        }
    }
}