using Microsoft.AspNetCore.Mvc;
using THWEB.Models;
using THWEB.Services;

namespace THWEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublishersController : ControllerBase
    {
        private readonly IReponsitoryP _repon;
        public PublishersController(IReponsitoryP repon) { _repon = repon; }
        [HttpGet]
        public IActionResult GetAllPublisher()
        {
            try
            {
                return Ok(_repon.GetALlPublishers());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("id")]
        public IActionResult GetPublisher(int id)
        {
            try
            {

                return Ok(_repon.GetPublisher(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult PostPublishers(PublishersVM publishersVM)
        {
            try
            {

                return Ok(_repon.AddPublisher(publishersVM));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete]
        public IActionResult DeletePublisher(int id)
        {
            try
            {
                _repon.DeletePublisher(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        public IActionResult Update(int id, PublishersVM publishersVM)
        {
            if (id != publishersVM.PublisherId)
            {
                return NoContent();
            }
            try
            {
                _repon.UpdatePublisher(id, publishersVM);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
