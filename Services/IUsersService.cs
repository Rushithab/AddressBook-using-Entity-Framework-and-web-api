using Addressbookapi.Models;

namespace Addressbookapi.Services
{
    public interface IUsersService
    {
        public List<Contact> Get();
        public Contact Get(int id);
        public int Create(Contact contact);
        public bool Update(Contact contact,int id);
        public bool Delete(int id);
    }
}
