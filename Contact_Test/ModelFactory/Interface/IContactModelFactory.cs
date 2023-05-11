using Contact_Test.Models;

namespace Contact_Test.ModelFactory.Interface
{
    public interface IContactModelFactory
    {
        ContactModel PrepareContactModel(ContactModel model);
    }
}
