using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using THWEB.Data;
using THWEB.Models;
using THWEB.Services;

namespace THWEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]

    public class BookController : ControllerBase
    {
        private readonly AppDbcontext _appDbcontext;
        private readonly ILogger<BookController> _logger;
        private readonly IReponsitoryB _repon;
        public BookController(IReponsitoryB repon, ILogger<BookController> logger )
        {
            _repon = repon; _logger = logger;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllBook(string ?search,string ? sort,int page=1)
        {
            try
            {
                return Ok(_repon.GetAllbooks(search,sort,page));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("id")]
        [AllowAnonymous]

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
        public IActionResult Update( BooksVM books)
        {
            try
            {
                _repon.UpdateBook( books);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
