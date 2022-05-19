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
    public class AddressesController : ControllerBase
    {
        private IAddressService _addressService;
        private IContactService _contactService;
        public AddressesController(IAddressService addressService, IContactService contactService)
        {
            _addressService = addressService;
            _contactService = contactService;
        }
        // GET: api/<AddressesController>
        [HttpGet]
        public async Task<List<AddressResponse>> GetAddresses()
        {
            var addresses = await _addressService.GetAddresses();
            return AddressResponse.GetResponseList(addresses);           
        }       

        // GET api/<AddressesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAddressById(int id)
        {
            if (id <= 0 )
            {
                return BadRequest("id must be positive integer");
            }
            var address = await _addressService.GetAddressById(id);
            if (address == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"address with id {id} not found");
            }
            return Ok(address);
        }

        // POST api/<AddressesController>
        [HttpPost]
        public async Task<ActionResult> AddAddress([FromBody] AddressRequest addressRequest)
        {
            var address = await _addressService.GetAddressById(addressRequest.Id);
            
            if (address == null)                            //mi hat nayel a petq es method @
            {
                var addressInfo = new AddressModel()
                {                   
                    City = addressRequest.City,
                    Street = addressRequest.Street,              
                    Building = addressRequest.Building,
                    Apartment = addressRequest.Apartment,
                };
               
                
                await _addressService.AddAddress(addressInfo);
                return Ok(addressInfo); 
            }
            return BadRequest($"Error message ");            
        }

        // PUT api/<AddressesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AddressResponse>> UpdateAddress(int id, [FromBody] AddressRequest addressRequest)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be positive integer");
            }
            var address = _addressService.GetAddressById(id);
            if (address != null)
            {
                var addressModel = new AddressModel()
                {                   
                    City = addressRequest.City,
                    Street = addressRequest.Street,
                    Building = addressRequest.Building,
                    Apartment = addressRequest.Apartment,
                };

                var newAddressModel = await _addressService.UpdateAddressComplete(id, addressModel);
                return Ok(newAddressModel);

            }
            return StatusCode(StatusCodes.Status400BadRequest, $"address with id {id} not found");

        }

        // DELETE api/<AddressesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAddress(int id)
        {
            if (id<=0)
            {
                return BadRequest("invalid id provided");
            }
            var result = await _addressService.GetAddressById(id);  

            if (result != null)
            {
               await _addressService.DeleteAddress(id);
                return Ok($"address with Id {id} was  successfully deleted.");
            }
            return StatusCode(StatusCodes.Status404NotFound, $"address with id {id} not founded");
        }
    }
}
