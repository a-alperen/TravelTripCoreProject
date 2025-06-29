using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelTripCoreProject.Models.Classes;
using Newtonsoft.Json;
using TravelTripCoreProject.Models;
using TravelTripCoreProject.DataAccessLayer.Contexts;
using TravelTripCoreProject.Business.Services;
using TravelTripCoreProject.Models.ViewModels;

namespace TravelTripCoreProject.Controllers
{
    public class BlogController(IBlogService blogService, ICommentService commentService) : Controller
    {
        private readonly IBlogService _blogService = blogService;
        private readonly ICommentService _commentService = commentService;

        public IActionResult Index(int? i)
        {
            int pageSize = 5;
            int pageNumber = i ?? 1;
            int skip = (pageNumber - 1) * pageSize;

            var blogs = _blogService.GetPagedBlogs(skip, pageSize).ToList();
            int totalItems = _blogService.GetAllBlogs().Count;

            var viewModel = new BlogListViewModel
            {
                Blogs = blogs,
                TotalItems = totalItems,
                HasNextPage = (skip + pageSize) < totalItems,
                HasPreviousPage = pageNumber > 1,
                CurrentPage = pageNumber,
                PageSize = pageSize
            };

            return View(viewModel);
        }
        public IActionResult BlogDetail(int id)
        {
            var blog = _blogService.GetById(id);
            if (blog == null)
                return NotFound();
            BlogDetailViewModel viewModel = new BlogDetailViewModel
            {
                Blog = blog,
                Comments = _commentService.GetCommentsByBlogId(id),
                LastBlogs = _blogService.GetAllBlogs()
                    .OrderByDescending(b => b.DateTime)
                    .Take(3)
                    .ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult LeaveComment(int blogId, string username, string email, string userComment)
        {
            var comment = _commentService.AddComment(blogId, username, email, userComment);
            if (comment != null)
            {
                // Yorum başarıyla eklendi.
                return RedirectToAction("BlogDetail", new { id = blogId });
            }
            else
            {
                // Hata durumu
                ModelState.AddModelError("", "Yorum eklenemedi.");
                return View();
            }
        }

    }
}