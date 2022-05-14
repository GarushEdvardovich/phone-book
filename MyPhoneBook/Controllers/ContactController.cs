using Microsoft.AspNetCore.Mvc;
using MyPhoneBook.Bll.IMyPhoneBookServices;
using MyPhoneBook.Models;
using MyPhoneBook.Requests;
using MyPhoneBook.Response;

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
        public async Task<List<ContactResponse>> GetContacts()
        {
            var contactModelList = await _contactInfoService.GetContacts();
            var contactResponseList = ContactResponse.GetResponseList(contactModelList);
            return contactResponseList;
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<ContactResponse?> GetContact(int id)
        {
            var contact = await _contactInfoService.GetContactById(id);
            return contact == null ? null : new ContactResponse(contact);
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<ContactResponse> CreateContact([FromBody] ContactRequest contactRequest)
        {
            var contactModel = new ContactModel()
            {
                PrimaryPhoneNumber = contactRequest.PrimaryPhoneNumber,
                SecondaryPhoneNumber = contactRequest.SecondaryPhoneNumber,
                Email = contactRequest.Email,
                FirstName = contactRequest.FirstName,
                LastName = contactRequest.LastName,
            };
            var contact = await _contactInfoService.AddContact(contactModel);
            var contactResponse = new ContactResponse(contact);

            return contactResponse;
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public async Task<ContactResponse> UpdateContact(int id, [FromBody] ContactRequest contactRequest)

        {
            var contact = await _contactInfoService.GetContactById(id);
            if (contact != null)
            {
                var contactModel = new ContactModel()
                {
                    PrimaryPhoneNumber = contactRequest.PrimaryPhoneNumber,
                    SecondaryPhoneNumber = contactRequest.SecondaryPhoneNumber,
                    Email = contactRequest.Email,
                    FirstName = contactRequest.FirstName,
                    LastName = contactRequest.LastName,
                };
                var updatedConatct = await _contactInfoService.UpdateContact(id, contactModel);
                return new ContactResponse(contactModel);//new ContactResponse(updatedConatct);
            }
            return null;

        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _contactInfoService.GetContactById(id);

            if (contact != null)
            {
                return new JsonResult(await _contactInfoService.DeleteContact(id));
            }
            return StatusCode(404);
        }
    }
}
