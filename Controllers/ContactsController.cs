using Addressbookapi.Models;
using Addressbookapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Addressbookapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactRepository)
        {
            _contactService = contactRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetContacts()
        {
            var allData= _contactService.GetContacts();
            return Ok(allData);
        }
        [HttpGet("{id}")]
        public ActionResult<Contact> GetContactById(int id)
        {
            var Data= _contactService.GetContactById(id);
            return Ok(Data);
        }
        [HttpPost]
        public ActionResult<Contact> PostContact([FromBody] Contact contact)
        {
            _contactService.CreateContact(contact);
            return Ok();
        }
        [HttpPut]
        public ActionResult PutContact([FromBody] Contact contact,int id)
        {
            var updatedData=  _contactService.UpdateContact(contact,id);
            return Ok(updatedData); 
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteContact(int id)
        {
            var contactToDelete =  _contactService.GetContactById(id);
            _contactService.DeleteContact(contactToDelete.Id);
            return Ok() ;
        }
    }
}
