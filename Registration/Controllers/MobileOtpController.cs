using Microsoft.AspNetCore.Mvc;
using Registration.DTOS;
using Registration.Interfaces;
using Registration.Utilities;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileOtpController : ControllerBase
    {
        private readonly IMobileOtpService _otpService;
        public MobileOtpController(IMobileOtpService otpService)
        {
            _otpService = otpService;
        }

        [HttpPost("request-otp")]
        public async Task<IActionResult> RequestOtp([FromBody] MobileOtpRequestDto otpRequest)
        {
            try
            {
                var result = await _otpService.GenerateOtp(otpRequest);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, ResponseMessages.DatabaseError);
            }
        }

        [HttpPost("resend-otp")]
        public async Task<IActionResult> ResendOtp([FromBody] MobileOtpRequestDto otpRequest)
        {
            try
            {
                var result = await _otpService.GenerateOtp(otpRequest, true);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, ResponseMessages.DatabaseError);
            }
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] MobileOtpVerificationDto otpVerification)
        {
            try
            {
                var result = await _otpService.VerifyOtp(otpVerification);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, ResponseMessages.DatabaseError);
            }
        }
    }
}