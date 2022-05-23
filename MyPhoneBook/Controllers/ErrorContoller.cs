using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyPhoneBook.Controllers
{
    [Route("/Error")]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error(int statusCode)
        {

            return NotFound(); /*Json(new { statusCode = Response.StatusCode })*/

           
        }
    }
}
