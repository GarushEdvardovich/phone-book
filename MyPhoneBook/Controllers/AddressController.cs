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
        public async Task<AddressResponse> GetAddressById(int id)
        {
            var address = await _addressService.GetAddressById(id);
            return new AddressResponse(address);
        }

        // POST api/<AddressesController>
        [HttpPost]
        public /*ActionResult*/ async Task<AddressResponse> AddAddress([FromBody] AddressRequest addressRequest)
        {
            var address = await _addressService.GetAddressById(addressRequest.Id);
            if (address == null)
            {
                var addressInfo = new AddressModel()
                {
                    City = addressRequest.City,
                    Street = addressRequest.Street,
                    Building = addressRequest.Building,
                    Apartment = addressRequest.Apartment,
                };

             
                await _addressService.AddAddress(addressInfo);
                var addressResponse = new AddressResponse(addressInfo);
                return /*Ok(addressResponse)*/addressResponse;
            }
            return null;

            
        }

        // PUT api/<AddressesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AddressResponse>> UpdateAddress(int id, [FromBody] AddressRequest addressRequest)
        {
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

                /*var addressModel =*/ await _addressService.UpdateAddressComplete(id, addressModel);
                return Ok("updated success");

            }
            return null;

        }

        // DELETE api/<AddressesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {

            var result = await _addressService.GetAddressById(id);  

            if (result != null)
            {
                return new JsonResult(await _addressService.DeleteAddress(id));
            }
            return StatusCode(404);
        }
    }
}
