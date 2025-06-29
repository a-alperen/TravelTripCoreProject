using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.Models.ViewModels
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