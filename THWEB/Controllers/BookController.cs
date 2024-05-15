using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using THWEB.Data;
using THWEB.Models;
using THWEB.Services;

namespace THWEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class BookController : ControllerBase
    {
        private readonly AppDbcontext _appDbcontext;
        private readonly ILogger<BookController> _logger;
        private readonly IReponsitoryB _repon;
        private readonly ITokenRepository _tokenRepository;

        public BookController(IReponsitoryB repon, ILogger<BookController> logger, ITokenRepository tokenRepository, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _repon = repon; _logger = logger;
            _tokenRepository = tokenRepository;
        }
        [HttpGet]
        
        [Authorize(Roles = "Read")]
        public IActionResult GetAllBook(string ?search,string ? sort,int page=1)
        {
            try
            {
                _logger.LogInformation("GetAll Book Action method was invoked");
                _logger.LogWarning("This is a warning log");
                _logger.LogError("This is a error log");
                var allBooks = _repon.GetAllbooks(search, sort, page);
                _logger.LogInformation($"Finished GetAllBook request with data { JsonSerializer.Serialize(allBooks)}");
                return Ok(allBooks);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("id")]
        
        [Authorize(Roles = "Read,Write")]
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
        [Authorize(Roles = "Read,Write")]

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
        [Authorize(Roles = "Read,Write")]
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
        [Authorize(Roles = "Read,Write")]
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
