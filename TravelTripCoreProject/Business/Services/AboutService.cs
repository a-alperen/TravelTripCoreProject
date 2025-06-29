using TravelTripCoreProject.DataAccessLayer.Repositories;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.Business.Services
{
    public class AboutService(IAboutRepository aboutRepository) : IAboutService
    {
        private readonly IAboutRepository _aboutRepository = aboutRepository;
        public List<About> GetAll()
        {
            return _aboutRepository.GetAllAbouts().ToList();
        }
    }
}
