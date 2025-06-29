using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.Business.Services
{
    public interface IContactService
    {
        bool AddContact(Contact contact);
        List<Contact> GetAllContacts();
    }
}
