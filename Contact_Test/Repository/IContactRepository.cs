using Contact_Test.Data;
using Contact_Test.Models;
using System.Collections.Generic;

namespace Contact_Test.Repository
{
    public interface IContactRepository
    {
        bool AddContact(ContactModel model);
        bool UpdateContact(ContactModel model);
        bool DeleteContact(int id);
        ContactModel GetContact(int id);
        IEnumerable<ContactModel> GetContacts();
        bool IsEmailExists(string email, int id);
        IEnumerable<Country> GetCountries();
    }
}
