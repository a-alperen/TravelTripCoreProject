using System;
using System.Collections.Generic;
using System.Linq;
using TravelTripCoreProject.Services;
using X.PagedList;

namespace TravelTripCoreProject.Models.Classes
{
    public class BlogListViewModel
    {
        public List<Blog> Blogs { get; set; }
        public int TotalItems { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}