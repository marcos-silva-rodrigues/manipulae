using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace manipulae.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {

        [HttpGet]
        public Dictionary<string, string> HelloMessage()
        {
            var json = new Dictionary<string, string>();
            json.Add("Message", "Hello Manipulae");
            return json;
        }
    }
}
