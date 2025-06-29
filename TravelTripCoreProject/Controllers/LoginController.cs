using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TravelTripCoreProject.Models.Classes;
using TravelTripCoreProject.DataAccessLayer.Contexts;

namespace TravelTripCoreProject.Controllers
{
    public class LoginController(Context context) : Controller
    {
        private readonly Context _context = context;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Admin admin)
        {
            var info = _context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (info != null)
            {
                // Claims ile kullanıcı kimliği oluştur
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, info.Username)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Kullanıcıyı cookie ile login et
                await HttpContext.SignInAsync("CookieAuth", principal);

                // İstersen Session'a ek veri koyabilirsin (Opsiyonel)
                HttpContext.Session.SetString("User", info.Username);

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.Error = "Kullanıcı adı veya şifre yanlış!";
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login", "Login");
        }
    }
}