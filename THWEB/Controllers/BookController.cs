using Microsoft.AspNetCore.Mvc;
using THWEB.Models;
using THWEB.Services;

namespace THWEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {

        private readonly IReponsitoryB _repon;
        public BookController(IReponsitoryB repon) { _repon = repon; }
        [HttpGet]
        public IActionResult GetAllBook()
        {
            try
            {
                return Ok(_repon.GetAllbooks());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("id")]
        public IActionResult GetBookid(int id)
        {
            try
            {

                return Ok(_repon.GetBook(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult PostBook(BooksVM book)
        {
            try
            {
                return Ok(_repon.AddBookWithAuthors(book));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                _repon.DeleteBook(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut]
        public IActionResult Update(int id, BooksVM books)
        {
            if (id != books.BookId)
            {
                return NoContent();
            }
            try
            {
                _repon.UpdateBook(id, books);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
