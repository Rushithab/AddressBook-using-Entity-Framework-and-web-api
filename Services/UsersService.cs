using Addressbookapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Addressbookapi.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactContext _context;
        public ContactService(ContactContext context)
        {
            _context = context;
        }
        public int CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            var contactId=contact.Id;
            return contactId;
        }
        public bool DeleteContact(int id)
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
        public List<Contact> GetContacts()
        {
            var allContacts= _context.Contacts.ToList();
            return allContacts;
        }
        public Contact GetContactById(int id)
        {
            return _context.Contacts.Find(id);
        }
        public bool UpdateContact(Contact contact,int id)
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
