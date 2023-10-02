using manipulae.Data.Dto;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Video[]> FindAll([FromQuery] string? q, [FromQuery] DateTime? after)
        {
            var videos = _service.GetVideosAndFilter(q, after);
            return Ok(videos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Video> Find(string id)
        {
            var video = _service.FindVideoById(id);
            if (video == null) return NotFound();
            return Ok(video);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult Create([FromBody] CreateVideoDto dto)
        {
            var video = _service.Insert(dto);
            if (video == null)
            {
                return Conflict();
            }
            return CreatedAtAction(nameof(Find), new { Id = video.Id }, video);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateVideoById(string id, [FromBody] UpdateVideoDto dto)
        {
            var isSucessfull = _service.Update(id, dto);
            if (isSucessfull)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteById(string id)
        {
            var isSucessfull = _service.MarkDeleted(id);
            if (isSucessfull)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
