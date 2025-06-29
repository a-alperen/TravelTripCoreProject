using TravelTripCoreProject.DataAccessLayer.Repositories;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.Business.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public Comment? AddComment(int blogId, string username, string email, string userComment)
        {
            var comment = new Comment
            {
                BlogId = blogId,
                Username = username,
                Email = email,
                UserComment = userComment
            };
            _commentRepository.Add(comment);
            return comment;
        }

        public bool DeleteComment(int id)
        {
            var comment = _commentRepository.GetById(id);
            if (comment == null) return false;

            _commentRepository.Delete(id);
            return true;
        }

        public List<Comment> GetAllComments()
        {
            return _commentRepository.GetAllComments().ToList();
        }

        public Comment? GetCommentById(int id)
        {
            return _commentRepository.GetById(id);
        }

        public List<Comment> GetCommentsByBlogId(int id)
        {
            return _commentRepository.GetAllComments()
                .Where(c => c.BlogId == id)
                .ToList();
        }

        public bool UpdateComment(Comment comment)
        {
            var existing = _commentRepository.GetById(comment.Id);
            if (existing == null) return false;

            existing.Username = comment.Username;
            existing.Email = comment.Email;
            existing.UserComment = comment.UserComment;

            _commentRepository.Update(existing);
            return true;
        }
    }
}
