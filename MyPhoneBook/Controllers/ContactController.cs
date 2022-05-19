using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPhoneBook.Bll.IMyPhoneBookServices;
using MyPhoneBook.Models;
using MyPhoneBook.Requests;
using MyPhoneBook.Response;
using System;
using System.Text.Json;

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
        public async Task<List<ContactResponse>> GetContacts()
        {
            var contactModelList = await _contactInfoService.GetContacts();
            var contactResponseList = ContactResponse.GetResponseList(contactModelList);
            return contactResponseList;
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
       
        public async Task<ActionResult> GetContact(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id must be positive integer");
            }
            var contact = await _contactInfoService.GetContactById(id);
            if (contact == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"contact with id {id} not found");
            }
            return Ok(contact);
        }

        // POST api/<ContactController>
        [HttpPost]      
        public async Task<ActionResult> CreateContact([FromBody] ContactRequest contactRequest)
        {           
            var contactModel = new ContactModel()
            {                
                AddressId = contactRequest.AddressId,
                PrimaryPhoneNumber = contactRequest.PrimaryPhoneNumber,
                SecondaryPhoneNumber = contactRequest.SecondaryPhoneNumber,
                Email = contactRequest.Email,
                FirstName = contactRequest.FirstName,
                LastName = contactRequest.LastName,
            };   
            
            var contact = await _contactInfoService.AddContact(contactModel);
            if (contact != null)
            {
                return new ObjectResult(contact);
            }
            return BadRequest("Invalid contact model");
            
        }


        // PUT api/<ContactController>/5
        [HttpPut("{id}")]        
        public async Task <ActionResult> UpdateContact(int id, [FromBody] ContactRequest contactRequest)

        {
            if (id <= 0 )
            {
                return BadRequest("Invalid id provided, it must be positive integer ");

            }
            var contact = await _contactInfoService.GetContactById(id);
            if (contact != null)
            {
                var contactModel = new ContactModel()
                {
                    AddressId=contactRequest.AddressId,
                    PrimaryPhoneNumber = contactRequest.PrimaryPhoneNumber,
                    SecondaryPhoneNumber = contactRequest.SecondaryPhoneNumber,
                    Email = contactRequest.Email,
                    FirstName = contactRequest.FirstName,
                    LastName = contactRequest.LastName,
                };
                var updatedContact = await _contactInfoService.UpdateContact(id,contactModel);
                return Ok(updatedContact);
            }
            return StatusCode(StatusCodes.Status404NotFound, $"contact with id {id} could not be updated");

        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("invalid id provided");
            }
            var result = await _contactInfoService.GetContactById(id);
            if (result != null)
            {
                await _contactInfoService.DeleteContact(id);
                return Ok($"contact with Id {id} was  successfully deleted.");
            }
            return StatusCode(StatusCodes.Status404NotFound, $"contact with id {id} not founded");
        }
    }
}

