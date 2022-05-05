using Microsoft.EntityFrameworkCore;

namespace Addressbookapi.Models
{
    public class ContactContext:DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
