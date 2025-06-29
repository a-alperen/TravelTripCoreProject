using TravelTripCoreProject.DataAccessLayer.Contexts;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.DataAccessLayer.Repositories
{
    public class ContactRepository(Context context) : IContactRepository
    {
        private readonly Context _context = context;
        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public IQueryable<Contact> GetAllContacts()
        {
            return _context.Contacts;
        }
    }
}
