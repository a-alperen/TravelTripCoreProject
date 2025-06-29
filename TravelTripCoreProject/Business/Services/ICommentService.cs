using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.Business.Services
{
    public interface ICommentService
    {
        Comment? AddComment(int blogId, string username, string email, string userComment);
        bool UpdateComment(Comment comment);
        bool DeleteComment(int id);
        List<Comment> GetAllComments();
        Comment? GetCommentById(int id);
        List<Comment> GetCommentsByBlogId(int id);
    }
}
