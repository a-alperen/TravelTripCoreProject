using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.DataAccessLayer.Repositories
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        IQueryable<Contact> GetAllContacts();
    }
}
