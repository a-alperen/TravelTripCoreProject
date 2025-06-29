using TravelTripCoreProject.DataAccessLayer.Repositories;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.Business.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public bool AddBlog(Blog blog)
        {
            if (blog == null) return false;
            _blogRepository.AddBlog(blog);
            return true;
        }

        public bool UpdateBlog(Blog blog)
        {
            var existing = _blogRepository.GetById(blog.Id);
            if (existing == null) return false;

            existing.Title = blog.Title;
            existing.Description = blog.Description;
            existing.BlogImage = blog.BlogImage;
            existing.DateTime = blog.DateTime;

            _blogRepository.UpdateBlog(existing);
            return true;
        }

        public bool DeleteBlog(int id)
        {
            var existing = _blogRepository.GetById(id);
            if (existing == null) return false;

            _blogRepository.DeleteBlog(id);
            return true;
        }

        public Blog GetById(int id)
        {
            return _blogRepository.GetById(id);
        }

        public List<Blog> GetPagedBlogs(int skip, int take)
        {
            return _blogRepository.GetAllBlogs()
                .OrderByDescending(b => b.DateTime)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public List<Blog> GetAllBlogs()
        {
            return _blogRepository.GetAllBlogs().OrderByDescending(x => x.DateTime).ToList();
        }
    }
}
