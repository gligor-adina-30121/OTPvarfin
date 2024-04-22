using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace otp1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OTPController : ControllerBase
    {
        private readonly IOneTimePasswordService _otpService;

        public OTPController(IOneTimePasswordService otpService)
        {
            _otpService = otpService;
        }

        [HttpGet("generate")]
        public ActionResult<object> GenerateOTP()
        {
            var otp = _otpService.GenerateOTP();
            return Ok(new { otp = otp });
        }
        [HttpPost("validate")]
        public ActionResult<bool> ValidateOTP([FromBody] string otp)
        {
            return Ok(_otpService.ValidateOTP(otp));
        }
    }
}
