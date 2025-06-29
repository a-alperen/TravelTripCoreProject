using System;
using System.Collections.Generic;
using System.Linq;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.Models.ViewModels
{
    public class BlogDetailViewModel
    {
        public Blog Blog { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Blog> LastBlogs { get; set; }
    }
}