using Microsoft.AspNetCore.Mvc;
using MyPhoneBook.Bll.IMyPhoneBookServices;
using MyPhoneBook.Requests;
using MyPhoneBook.Response;

namespace MyPhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private IAddressService _addressService;
        private readonly ILogger<AddressesController> _logger;

        public AddressesController(IAddressService addressService, ILogger<AddressesController> logger)
        {
            _addressService = addressService;
            _logger = logger;
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
        public async Task<IActionResult> GetAddressById(int id)
        {
            if (id <= 0)
            {               
                return BadRequest("id must be positive integer");
            }

            var address = await _addressService.GetAddressById(id);

            if (address == null)
            {
                return NotFound(); 

               // return StatusCode(StatusCodes.Status404NotFound, $"address with id {id} not found");
            }
           

           return Ok(address);
        }

        // POST api/<AddressesController>
        [HttpPost]
        public async Task<ActionResult> AddAddress([FromBody] AddressRequest addressRequest)
        {   
            
            var addedAddress = await _addressService.AddAddress(addressRequest.GetPostAddressModel());


            return Ok(addedAddress);
        }

        // PUT api/<AddressesController>
        [HttpPut("{id}")]
        public async Task<ActionResult<AddressResponse>> UpdateAddress(int id, [FromBody] AddressRequest addressRequest)
        {
            if (id <= 0)
            {
                return BadRequest("id must be positive integer");
            }
            else if (id != addressRequest.Id)
            {
                return BadRequest("id in the body is different from the endpoint id ");
            }

            var updatedAddressModel = await _addressService.UpdateAddress(id, addressRequest.GetPutAddressModel());

            if (updatedAddressModel != null)
            {
                return Ok(updatedAddressModel);
            }

            return StatusCode(StatusCodes.Status400BadRequest, $"address with id {id} not found");


        }

        // DELETE api/<AddressesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAddress(int id)
        {
            if (id <= 0)
            {
                return BadRequest("id must be positive integer");
            }
           
               var result = await _addressService.DeleteAddress(id);

            if (result)
            {
                return Ok($"address with Id {id} was  successfully deleted.");
            }

            return StatusCode(StatusCodes.Status404NotFound, $"address with id {id} not founded");
        }
    }
}
