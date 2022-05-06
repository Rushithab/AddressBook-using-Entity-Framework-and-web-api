using Addressbookapi.Models;

namespace Addressbookapi.Services
{
    public interface IContactService
    {
        public List<Contact> GetContacts();
        public Contact GetContactById(int id);
        public int CreateContact(Contact contact);
        public bool UpdateContact(Contact contact,int id);
        public bool DeleteContact(int id);
    }
}
