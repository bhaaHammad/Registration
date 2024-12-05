using Microsoft.AspNetCore.Mvc;
using Registration.DTOS;
using Registration.Interfaces;
using Registration.Utilities;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailOtpController : ControllerBase
    {
        private readonly IEmailOtpService _emailOtpService;
        public EmailOtpController(IEmailOtpService emailOtpService)
        {
            _emailOtpService = emailOtpService;
        }

        [HttpPost("send-email-otp")]
        public async Task<IActionResult> SendEmailOtp([FromBody] EmailOtpRequestDto otp)
        {
            try
            {
                var result = await _emailOtpService.SendEmailOtp(otp);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, ResponseMessages.DatabaseError);
            }
        }

        [HttpPost("verify-email-otp")]
        public async Task<IActionResult> VerifyEmailOtp([FromBody] EmailOtpVerificationDto otpVerification)
        {
            try
            {
                var result = await _emailOtpService.VerifyEmailOtp(otpVerification);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, ResponseMessages.DatabaseError);
            }
        }
    }
}
