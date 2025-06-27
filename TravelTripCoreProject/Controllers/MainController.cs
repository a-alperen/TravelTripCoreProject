using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelTripCoreProject.Models.Classes;
using TravelTripCoreProject.Services;

namespace TravelTripCoreProject.Controllers
{
    public class MainController(Context context, GraphQLService graphQLService) : Controller
    {
        // GET: Main
        private readonly Context _context = context;
        private readonly GraphQLService _graphQLService = graphQLService;

        public IActionResult Index()
        {
            var values = _context.Blogs.Take(6).ToList();

            return View(values);
        }
        public IActionResult About()
        {
            var values = _context.Abouts.ToList();
            return View(values);
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(string name, string email, string message, string subject)
        {
            var result = await _graphQLService.AddContactAsync(name, email, message, subject);
            ViewBag.Message = result != null ? "Mesajınız alındı!" : "Bir hata oluştu.";
            return View();
        }
    }
}