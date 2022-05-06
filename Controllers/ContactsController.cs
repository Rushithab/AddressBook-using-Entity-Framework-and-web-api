using Addressbookapi.Models;
using Addressbookapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Addressbookapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IUsersService _userService;
        public ContactsController(IUsersService contactRepository)
        {
            _userService = contactRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetContact()
        {
            var allData= _userService.Get();
            return Ok(allData);
        }
        [HttpGet("{id}")]
        public ActionResult<Contact> GetContact(int id)
        {
            var Data= _userService.Get(id);
            return Ok(Data);
        }
        [HttpPost]
        public ActionResult<Contact> PostContact([FromBody] Contact contact)
        {
            _userService.Create(contact);
            return Ok();
        }
        [HttpPut]
        public ActionResult PutContacts([FromBody] Contact contact,int id)
        {
            var updatedData=  _userService.Update(contact,id);
            return Ok(updatedData); 
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var contactToDelete =  _userService.Get(id);
            _userService.Delete(contactToDelete.Id);
            return Ok() ;
        }
    }
}
