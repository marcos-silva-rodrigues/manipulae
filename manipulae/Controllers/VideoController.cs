using manipulae.Data.Models;
using manipulae.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace manipulae.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {

        private readonly IVideoService _service;

        public VideoController(IVideoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<Video[]> FindAll()
        {
            var videos = _service.GetAllVideos();
            return Ok(videos);
        }
    }
}
