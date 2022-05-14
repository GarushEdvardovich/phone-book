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
        private IContactService _contactService;
        public AddressController(IAddressService addressService, IContactService contactService)
        {
            _addressService = addressService;
            _contactService = contactService;
        }
        // GET: api/<AddressController>
        [HttpGet]
        public async Task<List<AddressResponse>> GetAddresses()
        {
            var addresses = await _addressService.GetAddresses();
            var addresResponse = new AddressResponse().AResponseList(addresses); //AResponseList @ stanum em responsi mej chisht a?
            return addresResponse;
            //foreach (var address in addresses)
            //{
            //    addressList.Add(new AddressResponse(address));

            //}
            //return new JsonResult(addressList);
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<AddressResponse> GetAddressById(int id)
        {
            var address = await _addressService.GetAddressById(id);
            return new AddressResponse(address);
        }

        // POST api/<AddressController>
        [HttpPost]
        public /*ActionResult*/ async Task<AddressResponse> AddAddress([FromBody] AddressRequest addressRequest)
        {
            var contact = await _contactService.GetContactById(addressRequest.ContacId);
            if (contact != null)
            {
                var addressInfo = new AddressModel()
                {
                    ContactId = addressRequest.ContacId,
                    City = addressRequest.City,
                    Street = addressRequest.Street,
                    Building = addressRequest.Building,
                    Appartment = addressRequest.Appartment,
                };

                /* var address = */
                await _addressService.AddAddress(addressInfo);
                var addressResponse = new AddressResponse(addressInfo);
                return /*Ok(addressResponse)*/addressResponse;
            }
            return null;

            //try
            //{
            //    var address = new AddressResponse(_addressService.AddAddress(addressInfo));
            //    if (address != null)
            //        return new JsonResult(address);
            //    return BadRequest();
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, new { Message = $"oops, an unexpected failure: {ex.Message}" });
            //}
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public /*ActionResult*/async Task<AddressResponse> UpdateAddress(int id, [FromBody] AddressRequest addressRequest)
        {
            var contact = _addressService.GetAddressById(id);
            if (contact != null)
            {
                var addressModel = new AddressModel()
                {
                    ContactId = addressRequest.ContacId,
                    City = addressRequest.City,
                    Street = addressRequest.Street,
                    Building = addressRequest.Building,
                    Appartment = addressRequest.Appartment,
                };

                var address = await _addressService.UpdateAddressComplete(id, addressModel);
                return new AddressResponse(address);

            }
            return null;

        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {

            var result = await _addressService.GetAddressById(id);  // _addressService.DeleteAddress(id);

            if (result != null)
            {
                return new JsonResult(await _addressService.DeleteAddress(id));
            }
            return StatusCode(404);
        }
    }
}
