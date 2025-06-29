using TravelTripCoreProject.DataAccessLayer.Contexts;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.DataAccessLayer.Repositories
{
    public class CommentRepository(Context context) : ICommentRepository
    {
        private readonly Context _context = context;
        public void Add(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Comment not found");
            }
        }

        public Comment? GetById(int id)
        {
            return _context.Comments.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Comment comment)
        {
            _context.Comments.Update(comment);
            _context.SaveChanges();
        }

        public IQueryable<Comment> GetAllComments()
        {
            return _context.Comments;
        }
    }
}
