using Microsoft.AspNetCore.Mvc;
using Registration.DTOS;
using Registration.Interfaces;
using Registration.Utilities;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto user)
        {
            try
            {
                var result = await _userService.Register(user);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, ResponseMessages.DatabaseError);
            }
        }

        [HttpPost("add-pin")]
        public async Task<IActionResult> AddPin([FromBody] PinDto addPinDto)
        {
            try
            {
                var result = await _userService.AddPin(addPinDto);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, ResponseMessages.DatabaseError);
            }
        }

        [HttpPost("verify-pin")]
        public async Task<IActionResult> VerifyPin([FromBody] PinDto verifyPinDto)
        {
            try
            {
                var result = await _userService.VerifyPin(verifyPinDto);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, ResponseMessages.DatabaseError);
            }
        }

        [HttpPost("enable-biometrics")]
        public async Task<IActionResult> EnableBiometrics([FromBody] EnableBiometricsDto enableBiometricsDto)
        {
            try
            {
                var result = await _userService.EnableBiometrics(enableBiometricsDto);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, ResponseMessages.DatabaseError);
            }
        }

        [HttpPost("save-biometrics")]
        public async Task<IActionResult> SaveBiometrics([FromBody] SaveBiometricsDto saveBiometricsDto)
        {
            try
            {
                var result = await _userService.SaveBiometrics(saveBiometricsDto);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, ResponseMessages.DatabaseError);
            }
        }
    }
}
