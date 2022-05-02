using Microsoft.AspNetCore.Mvc;
using MyPhoneBook.Bll.IMyPhoneBookServices;
using MyPhoneBook.Models;
using MyPhoneBook.Requests;
using MyPhoneBook.Response;
using System.Net;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyPhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactService _contactInfoService;
        public ContactController(IContactService contacInfoService)
        {
            _contactInfoService = contacInfoService;
        }


        // GET: api/<ContactController>
        [HttpGet]
        public IActionResult GetContacts()
        {
            var contacts = _contactInfoService.GetContacts();
            var contactList = new List<ContactResponse>();
            
            foreach (var contact in contacts)
            {
                contactList.Add(new ContactResponse(contact));
            }

            return new JsonResult(contactList);
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var contact = _contactInfoService.GetContactById(id);
            if (contact == null)
            {
                return NotFound() ;
            }
            return new JsonResult( new ContactResponse(contact));

        }

        // POST api/<ContactController>
        [HttpPost]
        public IActionResult /*async Task<ContactModel> */ CreateContact([FromBody] ContactModel contactModel)
        {
            
           
            var contact =_contactInfoService.AddContact(contactModel);
            if (contactModel.Id == 0)
            {
                return BadRequest();
            }
            return Ok(contact);
            
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, [FromBody] ContactModel contactModel)  
        {           
            var updatedConatct = _contactInfoService.UpdateContact(contactModel);

            return new JsonResult(updatedConatct);
        }


       
        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contact = _contactInfoService.GetContactById(id);

            if (contact != null)
            {
                return new JsonResult(_contactInfoService.DeleteContact(id));
            }

            return StatusCode(404);
        }
    }
}
