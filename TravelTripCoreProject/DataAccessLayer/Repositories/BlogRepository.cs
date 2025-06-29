using System.Collections.Generic;
using System.Linq;
using TravelTripCoreProject.Models.Classes;
using TravelTripCoreProject.DataAccessLayer.Contexts;

namespace TravelTripCoreProject.DataAccessLayer.Repositories
{
    public class BlogRepository(Context context) : IBlogRepository
    {
        private readonly Context _context = context;
        
        public void AddBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }

        public void DeleteBlog(int id)
        {
            var blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                _context.SaveChanges();
            }

        }

        public Blog GetById(int id)
        {
            return _context.Blogs.FirstOrDefault(b => b.Id == id) 
                   ?? throw new Exception("Blog not found");
        }

        public void UpdateBlog(Blog blog)
        {
            _context.Blogs.Update(blog);
            _context.SaveChanges();
        }

        public IQueryable<Blog> GetAllBlogs()
        {
            return _context.Blogs;
        }
    }
}
