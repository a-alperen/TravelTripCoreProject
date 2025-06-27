using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelTripCoreProject.Models.Classes;
using TravelTripCoreProject.Services;

namespace TravelTripCoreProject.Controllers
{
    public class AdminController(Context context, GraphQLService graphQLService) : Controller
    {
        private readonly Context _context = context;
        private readonly GraphQLService _graphQLService = graphQLService;

        [Authorize]
        public IActionResult Index()
        {
            var values = _context.Blogs.ToList();
            return View(values);
        }
        public IActionResult Contact()
        {
            var values = _context.Contacts.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult NewBlog()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewBlog(Blog blog)
        {
            try
            {
                var result = await _graphQLService.AddBlogAsync(
                    blog.Title ?? "",
                    blog.Description ?? "",
                    blog.BlogImage ?? "",
                    blog.DateTime
                );
                if (result != null)
                {
                    TempData["BlogResult"] = "Blog başarıyla eklendi!";
                }
                else
                {
                    TempData["BlogResult"] = "Blog eklenemedi!";
                }
            }
            catch (Exception ex)
            {
                TempData["BlogResult"] = "Hata: " + ex.Message;
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var result = await _graphQLService.DeleteBlogAsync(id);
            TempData["Message"] = result ? "Blog silindi!" : "Hata!";
            return RedirectToAction("Index");
        }

        public IActionResult GetBlog(int id)
        {
            var blog = _context.Blogs.Find(id);
            return View("GetBlog", blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBlog(Blog blog)
        {
            try
            {
                var result = await _graphQLService.UpdateBlogAsync(
                    blog.Id,
                    blog.Title ?? "",
                    blog.Description ?? "",
                    blog.BlogImage ?? "",
                    blog.DateTime
                );
                if (result != null)
                {
                    TempData["BlogResult"] = "Blog başarıyla güncellendi!";
                }
                else
                {
                    TempData["BlogResult"] = "Blog güncellenemedi!";
                }
            }
            catch (Exception ex)
            {
                TempData["BlogResult"] = "Hata: " + ex.Message;
            }
            return RedirectToAction("Index");
        }


        public IActionResult CommentList()
        {
            var comments = _context.Comments
                .Include(x => x.Blog) // Blog verisini de getir
                .ToList();
            return View(comments);
        }

        public IActionResult DeleteComment(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
            return RedirectToAction("CommentList");
        }

        public IActionResult GetComment(int id)
        {
            var comment = _context.Comments.Find(id);
            return View("GetComment", comment);
        }

        [ValidateAntiForgeryToken]
        public IActionResult UpdateComment(Comment comment)
        {
            var cmmnt = _context.Comments.Find(comment.Id);
            if (cmmnt != null)
            {
                cmmnt.Username = comment.Username;
                cmmnt.Email = comment.Email;
                cmmnt.UserComment = comment.UserComment;
                _context.SaveChanges();
            }
            return RedirectToAction("CommentList");
        }
    }
}