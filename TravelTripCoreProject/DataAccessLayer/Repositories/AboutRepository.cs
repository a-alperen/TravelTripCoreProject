using TravelTripCoreProject.DataAccessLayer.Contexts;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.DataAccessLayer.Repositories
{
    public class AboutRepository(Context context) : IAboutRepository
    {
        private readonly Context _context = context;
        public IQueryable<About> GetAllAbouts()
        {
            return _context.Abouts;
        }
    }
}
