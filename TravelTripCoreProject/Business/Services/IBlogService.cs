using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.Business.Services
{
    public interface IBlogService
    {
        bool AddBlog(Blog blog);
        bool UpdateBlog(Blog blog);
        bool DeleteBlog(int id);
        Blog GetById(int id);
        List<Blog> GetPagedBlogs(int skip, int take);
        List<Blog> GetAllBlogs();
    }
}
