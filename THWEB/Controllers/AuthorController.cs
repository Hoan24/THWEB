using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;
        public AuthorController(IReponsitoryA repon,UserManager<IdentityUser> userManager,ITokenRepository tokenRepository) { _repon=repon; _userManager = userManager;_tokenRepository = tokenRepository; }
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.Username,
                Email = registerRequestDTO.Username
            };
            var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDTO.Password);
            if (identityResult.Succeeded)
            {
                //add roles to this user
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);
                }
                if (identityResult.Succeeded)
                {
                    return Ok("Register Successful! Let login!");
                }
            }
            return BadRequest("Something wrong!");
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDTO.Username);
            if (user != null)
            {
                var checkPasswordResult = await
                _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
                if (checkPasswordResult)
                { //get roles for this user
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null)
                    { //create token
                        var jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwtToken
                        };
                        return Ok(response);
                    }
                }
            }
            return BadRequest("Username or password incorrect");
        }
        [HttpGet]
        [Authorize(Roles = "Read,Write")]
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
        [Authorize(Roles = "Read,Write")]

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
        public IActionResult PostAuthor(AuthorVM authorVM)
        {
            try
            {
                return Ok(_repon.AddAuthor(authorVM));
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
        public IActionResult Update(AuthorVM authorVM)
        {
           
                try
            {
                _repon.UpdateAuthor( authorVM);
                return Ok();
            }
            catch{
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
