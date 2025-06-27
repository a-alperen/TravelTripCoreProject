using EntityGraphQL.Schema;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.GraphQL
{
    public class ContactMutations
    {
        [GraphQLMutation("Add a new contact message")]
        public Expression<Func<Context, Contact>> AddContact(
            Context db,
            string name,
            string email,
            string subject,
            string message
        )
        {
            var contact = new Contact
            {
                NameSurname = name,
                Email = email,
                Subject = subject,
                Message = message
            };

            db.Contacts.Add(contact);
            db.SaveChanges();

            return ctx => ctx.Contacts.First(c => c.Id == contact.Id);
        }
    }
}
