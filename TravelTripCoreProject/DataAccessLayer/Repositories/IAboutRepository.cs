using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.DataAccessLayer.Repositories
{
    public interface IAboutRepository
    {
        IQueryable<About> GetAllAbouts();
    }
}
