using BookStoreApi.Interfaces;
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

        public AuthenticationController(IJwtTokenGenerator jwtToken)
        {
            _jwtToken = jwtToken;
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            var user = new IdentityUser
            {
                UserName = "wfatair",
                Email = "Wasim.fatair@gmail.com",
            };

            string token = _jwtToken.Generate(user);

            return Ok(new { token = token });

        }
    }
}
