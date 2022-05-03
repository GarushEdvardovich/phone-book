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
    public class AddressController : ControllerBase
    {
        private IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        // GET: api/<AddressController>
        [HttpGet]
        public IActionResult GetAddresses()
        {
            var addresses = _addressService.GetAddresses();
            var addressList = new List<AddressResponse>();
            foreach (var address in addresses)
            {
                addressList.Add(new AddressResponse(address));
              
            }
                return new JsonResult(addressList);
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public AddressResponse GetAddressById(int id)
        {
            var address = _addressService.GetAddressById(id);
            return new AddressResponse(address);
        }

        // POST api/<AddressController>
        [HttpPost]
        public IActionResult AddAddress([FromBody] AddressRequest addressRequest)
        {

            var addressInfo = new AddressModel()
            {
                ContactId = addressRequest.ContacId,
                City = addressRequest.City,
                Street = addressRequest.Street,
                Building = addressRequest.Building,
                Appartment = addressRequest.Appartment,
            };

            try
            {
                var address = new AddressResponse(_addressService.AddAddress(addressInfo));

                if (address != null)
                    return new JsonResult(address);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"oops, an unexpected failure: {ex.Message}" });
            }            
        }


        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public AddressModel UpdateAddress(int id, [FromBody] AddressRequest addressRequest)
        {
            var addressModel = new AddressModel()
            {
                Id = addressRequest.Id,
                City = addressRequest.City,
                Street = addressRequest.Street,
                Building = addressRequest.Building,
                Appartment = addressRequest.Appartment,
            };
            return _addressService.UpdateAddressComplete(addressModel);
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(int id)
        {
            var result = _addressService.DeleteAddress(id);

            if(result)
                return new JsonResult(result);
            
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
