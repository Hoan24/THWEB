using Microsoft.AspNetCore.Mvc;
using THWEB.Models;
using THWEB.Services;

namespace THWEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IReponsitoryA _repon;
        public AuthorController(IReponsitoryA repon) { _repon=repon; }
        [HttpGet]
        public IActionResult GetAllAuthor()
        {
            try
            {
                return Ok(_repon.GetAuthors());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("id")]
        public IActionResult GetAuthor(int id)
        {
            try
            {
                
                return Ok(_repon.GetAuthor(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult PostAuthor(AuthorVM authorVM,int Bookid)
        {
            try
            {
                return Ok(_repon.AddAuthor(authorVM,Bookid));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            try
            {
                _repon.DeleteAuthor(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        public IActionResult Update(int id,AuthorVM authorVM)
        {
            if (id != authorVM.AuthorId)
            {
                return NoContent();
            }
                try
            {
                _repon.UpdateAuthor(id, authorVM);
                return Ok();
            }
            catch{
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
