using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelTripCoreProject.Business.Services;
using TravelTripCoreProject.DataAccessLayer.Contexts;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.Controllers
{
    public class AdminController(IBlogService blogService, ICommentService commentService, IContactService contactService) : Controller
    {
        private readonly IBlogService _blogService = blogService;
        private readonly ICommentService _commentService = commentService;
        private readonly IContactService _contactService = contactService;

        [Authorize]
        public IActionResult Index()
        {
            var values = _blogService.GetAllBlogs();
            return View(values);
        }
        public IActionResult Contact()
        {
            var values = _contactService.GetAllContacts();
            return View(values);
        }
        [HttpGet]
        public IActionResult NewBlog()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewBlog(Blog blog)
        {
            if(_blogService.AddBlog(blog))
            {
                TempData["Message"] = "Blog başarıyla eklendi!";
            }
            else
            {
                TempData["Message"] = "Blog eklenemedi!";
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBlog(int id)
        {
            var result = _blogService.DeleteBlog(id);
            TempData["Message"] = result ? "Blog silindi!" : "Hata!";
            return RedirectToAction("Index");
        }

        public IActionResult GetBlog(int id)
        {
            var blog = _blogService.GetById(id);
            return View("GetBlog", blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBlog(Blog blog)
        {
            try
            {
                bool result = _blogService.UpdateBlog(blog);
                if (result)
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
            var comments = _commentService.GetAllComments();
            return View(comments);
        }

        public IActionResult DeleteComment(int id)
        {
            var result = _commentService.DeleteComment(id);
            TempData["Message"] = result ? "Yorum silindi!" : "Hata!";
            return RedirectToAction("CommentList");
        }

        public IActionResult GetComment(int id)
        {
            var comment = _commentService.GetCommentById(id);
            return View("GetComment", comment);
        }

        [ValidateAntiForgeryToken]
        public IActionResult UpdateComment(Comment comment)
        {
            var result = _commentService.UpdateComment(comment);
            TempData["Message"] = result ? "Blog düzenlendi!" : "Hata!";
            return RedirectToAction("CommentList");
        }
    }
}