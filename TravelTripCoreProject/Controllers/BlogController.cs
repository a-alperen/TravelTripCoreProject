using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelTripCoreProject.Models.Classes;
using X.PagedList;
using X.PagedList.Extensions;
using X.PagedList.Mvc.Core;
using TravelTripCoreProject.Services;
using Newtonsoft.Json;
using TravelTripCoreProject.Models;

namespace TravelTripCoreProject.Controllers
{
    public class BlogController(Context context, GraphQLService graphQLService) : Controller
    {
        private readonly Context _context = context;
        private readonly GraphQLService _graphQLService = graphQLService;

        //public IActionResult Index(int? i)
        //{
        //    int pageNumber = i ?? 1;
        //    int pageSize = 5;

        //    var viewModel = new BlogListViewModel
        //    {
        //        Blogs = _context.Blogs.OrderByDescending(x => x.Id).ToPagedList(pageNumber, pageSize),
        //        LastBlogs = [.. _context.Blogs.OrderByDescending(x => x.Id).Take(3)]
        //    };

        //    ViewData["Blogs"] = viewModel.Blogs;
        //    ViewData["LastBlogs"] = viewModel.LastBlogs;

        //    return View(viewModel);
        //}
        public async Task<IActionResult> Index(int? i)
        {
            int pageSize = 5;
            int pageNumber = i ?? 1;
            int skip = (pageNumber - 1) * pageSize;

            var pagedBlogs = await _graphQLService.GetPagedBlogsAsync(skip, pageSize);

            var viewModel = new BlogListViewModel
            {
                Blogs = pagedBlogs.items,
                TotalItems = pagedBlogs.totalItems,
                HasNextPage = pagedBlogs.hasNextPage,
                HasPreviousPage = pagedBlogs.hasPreviousPage,
                CurrentPage = pageNumber,
                PageSize = pageSize
            };

            return View(viewModel);
        }
        public async Task<IActionResult> BlogDetail(int id)
        {
            var blog = await _graphQLService.GetBlogByIdAsync(id);
            if (blog == null)
                return NotFound();

            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> LeaveComment(int blogId, string username, string email, string userComment)
        {
            var comment = await _graphQLService.AddCommentAsync(blogId, username, email, userComment);
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