
using Microsoft.AspNetCore.Mvc;

namespace shopbridge.controllers
{

    public class errorcontroller : Controller
    {
        [HttpGet]
        [Route("Error/{statusCode}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult pagenotfound(int statuscode)
        {
            return BadRequest("sorry the resource you requested could not be found.");
        }

        [HttpGet]
        [Route("Error/RequestFailed")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult RequestFailed(int statuscode)
        {
            return BadRequest("sorry the resource you requested could not be found.");
        }
    }
}
