using Microsoft.AspNetCore.Mvc;
using Registration.DTOS;
using Registration.Interfaces;
using Registration.Utilities;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var result = await _authenticationService.Login(loginDto);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, ResponseMessages.DatabaseError);
            }
        }
    }
}
