using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelTripCoreProject.Models.Classes
{
    public class BlogDetailViewModel
    {
        public Blog Blog { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Blog> LastBlogs { get; set; }
    }
}