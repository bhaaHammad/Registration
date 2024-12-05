using Registration.DTOS;
using Registration.Interfaces;
using Registration.Utilities;
using System.Runtime.Caching;
using MemoryCache = System.Runtime.Caching.MemoryCache;

namespace Registration.Services
{
    public class MobileOtpService : IMobileOtpService
    {
        private readonly MemoryCache _cache;

        public MobileOtpService()
        {
            _cache = MemoryCache.Default;
        }

        public Task<OperationResult> GenerateOtp(MobileOtpRequestDto otpRequest, bool isResend = false)
        {
            if (otpRequest == null || string.IsNullOrEmpty(otpRequest.PhoneNumber))
            {
                return Task.FromResult(OperationResult.FailureResult(ResponseMessages.InvalidOtpRequest));
            }

            var otp = new Random().Next(1000, 9999).ToString();

            var cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(2)
            };
            _cache.Set(otpRequest.PhoneNumber, otp, cacheItemPolicy);

            // Simulate sending OTP (in a real scenario, integrate with an SMS provider)
            Console.WriteLine($"OTP for {otpRequest.PhoneNumber}: {otp}");

            return Task.FromResult(OperationResult.SuccessResult(isResend ? ResponseMessages.OtpResentSuccessfully : ResponseMessages.OtpGeneratedSuccessfully));
        }

        public Task<OperationResult> VerifyOtp(MobileOtpVerificationDto otpVerification)
        {
            if (otpVerification == null || string.IsNullOrEmpty(otpVerification.PhoneNumber) || string.IsNullOrEmpty(otpVerification.Otp))
            {
                return Task.FromResult(OperationResult.FailureResult(ResponseMessages.InvalidOtpRequest));
            }

            var cachedOtp = _cache.Get(otpVerification.PhoneNumber) as string;
            if (cachedOtp == null)
            {
                return Task.FromResult(OperationResult.FailureResult(ResponseMessages.OtpExpired));
            }

            if (cachedOtp == otpVerification.Otp)
            {
                _cache.Remove(otpVerification.PhoneNumber);
                return Task.FromResult(OperationResult.SuccessResult(ResponseMessages.OtpVerifiedSuccessfully));
            }

            return Task.FromResult(OperationResult.FailureResult(ResponseMessages.InvalidOtp));
        }
    }
}
