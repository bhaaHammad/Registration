using Microsoft.AspNetCore.Mvc;
using Registration.DTOS;
using Registration.Interfaces;
using Registration.Utilities;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivacyPolicyController : ControllerBase
    {
        private readonly IPrivacyPolicyService _privacyPolicyService;
        public PrivacyPolicyController(IPrivacyPolicyService privacyPolicyService)
        {
            _privacyPolicyService = privacyPolicyService;
        }

        [HttpPost("accept-policy")]
        public async Task<IActionResult> AcceptPolicy([FromBody] PrivacyPolicyDto privacyPolicyDto)
        {
            try
            {
                var result = await _privacyPolicyService.AcceptPolicy(privacyPolicyDto);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, ResponseMessages.DatabaseError);
            }
        }
    }
}
