using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.DataAccessLayer.Repositories
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(int id);
        IQueryable<Comment> GetAllComments();
        Comment? GetById(int id);
    }
}
