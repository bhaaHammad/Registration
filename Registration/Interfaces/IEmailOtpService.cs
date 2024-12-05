using Registration.DTOS;
using Registration.Utilities;

namespace Registration.Interfaces
{
    public interface IEmailOtpService
    {
        public Task<OperationResult> SendEmailOtp(EmailOtpRequestDto otp);
        public Task<OperationResult> VerifyEmailOtp(EmailOtpVerificationDto otpVerification);
    }
}
