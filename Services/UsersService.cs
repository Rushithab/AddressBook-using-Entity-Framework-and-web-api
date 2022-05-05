using Addressbookapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Addressbookapi.Services
{
    public class UsersService : IUsersService
    {
        private readonly ContactContext _context;
        public UsersService(ContactContext context)
        {
            _context = context;
        }
        public Contact Create(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public bool Delete(int id)
        {
            var contactToDelete =  _context.Contacts.Find(id);
            if(contactToDelete != null)
            {
                _context.Contacts.Remove(contactToDelete);
                _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
        public List<Contact> Get()
        {
            var allData= _context.Contacts.ToList();
            return allData;
        }
        public Contact Get(int id)
        {
            return _context.Contacts.Find(id);
        }
        public bool Update(Contact contact,int id)
        {
            var contactToUpdate= _context.Contacts.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(contactToUpdate!=null)
            {
                _context.Entry(contact).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }    
    }
}
