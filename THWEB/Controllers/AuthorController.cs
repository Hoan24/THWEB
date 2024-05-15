using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using THWEB.Models;
using THWEB.Services;

namespace THWEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IReponsitoryA _repon;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthorController(IReponsitoryA repon, UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _repon = repon;
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }
       
        [HttpGet("get-all-author")]
        [Authorize(Roles = "Read,Write")]
        public IActionResult GetAllAuthor()
        {
            try
            {
                return Ok(_repon.GetAuthors());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Read,Write")]
        public IActionResult GetAuthor(int id)
        {
            try
            {
                return Ok(_repon.GetAuthor(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize(Roles = "Read,Write")]
        [HttpPost]
        public IActionResult PostAuthor(addAuthorVM authorVM)
        {
            try
            {
                return Ok(_repon.AddAuthor(authorVM));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize(Roles = "Read,Write")]
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            try
            {
                _repon.DeleteAuthor(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize(Roles = "Read,Write")]
        [HttpPut]
        public IActionResult Update(AuthorVM authorVM)
        {
            try
            {
                _repon.UpdateAuthor(authorVM);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
