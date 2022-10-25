using BookStoreApi.Data;
using BookStoreApi.DTOs;
using BookStoreApi.Interfaces;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtTokenGenerator _jwtToken;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationController(IJwtTokenGenerator jwtToken, UserManager<ApplicationUser> userManager)
        {
            _jwtToken = jwtToken;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm] LoginRequestDto login)
        {
            var user = await _userManager.FindByNameAsync(login.username);
            var token = "";
            if (user != null && await _userManager.CheckPasswordAsync(user, login.password))
            {
                token = _jwtToken.Generate(user);
            }
            else
                throw new UnauthorizedAccessException();

            return Ok(new { token = token });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequestDto registerRequestDto)
        {

            var userExists = await _userManager.FindByNameAsync(registerRequestDto.Username);
            if (userExists != null)
            {
                return BadRequest("User exists!");
            }
            

            ApplicationUser identityUser = new ApplicationUser
            {
                Email = registerRequestDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerRequestDto.Username,
                FirstName = registerRequestDto.FirstName,
                LastName = registerRequestDto.LastName
            };


            var result = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest("Error");
            }
            var token = _jwtToken.Generate(identityUser);

            return Ok(new RegisterResponseDto { Email = identityUser.Email, token = token, Username = identityUser.UserName });
        }
    }
}
