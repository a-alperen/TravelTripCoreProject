using System.Collections.Generic;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.DataAccessLayer.Repositories
{
    public interface IBlogRepository
    {
        IQueryable<Blog> GetAllBlogs();
        Blog GetById(int id);
        void AddBlog(Blog blog);
        void UpdateBlog(Blog blog);
        void DeleteBlog(int id);

    }
}
