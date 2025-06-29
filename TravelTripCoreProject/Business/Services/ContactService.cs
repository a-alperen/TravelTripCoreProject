using TravelTripCoreProject.DataAccessLayer.Repositories;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.Business.Services
{
    public class ContactService(IContactRepository contactRepository) : IContactService
    {
        private readonly IContactRepository _contactRepository = contactRepository;
        public bool AddContact(Contact contact)
        {
            if (contact == null) return false;
            _contactRepository.Add(contact);
            return true;
        }

        public List<Contact> GetAllContacts()
        {
            return _contactRepository.GetAllContacts().ToList();
        }
    }
}
