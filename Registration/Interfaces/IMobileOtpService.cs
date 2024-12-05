using Registration.DTOS;
using Registration.Utilities;

namespace Registration.Interfaces
{
    public interface IMobileOtpService
    {
        public Task<OperationResult> GenerateOtp(MobileOtpRequestDto otpRequest, bool isResend = false);
        public Task<OperationResult> VerifyOtp(MobileOtpVerificationDto otpVerification);
    }
}
