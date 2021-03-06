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
    public class ContactsController : ControllerBase
    {


        private IContactService _contactInfoService;
        public ContactsController(IContactService contacInfoService)
        {
            _contactInfoService = contacInfoService;
        }


        // GET: api/<ContactController>
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contactModelList = await _contactInfoService.GetContacts();
            return Ok(contactModelList);
        }


        // GET api/<ContactController>/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetContact(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id must be positive integer");
            }

            var contact = await _contactInfoService.GetContactById(id);

            if (contact == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"address with id {id} not found");
            }

            return Ok(contact);

        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] ContactRequest contactRequest)
        {            
            if (contactRequest.Id > 0)
            {
                return BadRequest("id cannot be assigned, it`s generated automatically, id mast be 0 ");
            }

            var addedcontact = await _contactInfoService.AddContact(contactRequest.GetPostContactModel());

            return Ok(addedcontact);         
        }
       


        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactRequest contactRequest)

        {
            if (string.IsNullOrWhiteSpace(contactRequest.FirstName))
            {
                return BadRequest("First name in the contact is mandatory.");
            }

            if (id != contactRequest.Id)
            {
                return BadRequest("id in the body is different from the endpoint id ");
            }

            var updatedContactModel = await _contactInfoService.UpdateContact(id, contactRequest.GetPutContactModel());
            
            if (updatedContactModel != null)
            {
                return Ok(updatedContactModel);
            }

            return StatusCode(StatusCodes.Status400BadRequest, $"contact with id {id} not found");           

        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            if (id <= 0)
            {
                return BadRequest("invalid id provided");
            }

            var result = await _contactInfoService.DeleteContact(id);

            if (result)
            {                
                return Ok($"contact with Id {id} was  successfully deleted.");
            }

            return StatusCode(StatusCodes.Status404NotFound, $"contact with id {id} not founded");
        }
    }
}
