using Microsoft.Extensions.Caching.Memory;
using Registration.Interfaces;
using Registration.Utilities;
using Registration.DTOS;
using MailKit.Security;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using Microsoft.Extensions.Options;

namespace Registration.Services
{
    public class EmailOtpService : IEmailOtpService
    {
        private readonly IMemoryCache _cache;
        private readonly EmailSettings _emailSettings;

        public EmailOtpService(IMemoryCache cache, IOptions<EmailSettings> emailSettings)
        {
            _cache = cache;
            _emailSettings = emailSettings.Value;
        }

        public async Task<OperationResult> SendEmailOtp(EmailOtpRequestDto emailOtp)
        {
            if (emailOtp == null || string.IsNullOrEmpty(emailOtp.EmailAddress))
            {
                return OperationResult.FailureResult(ResponseMessages.InvalidOtpData);
            }

            try
            {
                var otpCode = new Random().Next(1000, 9999).ToString();

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_emailSettings.FromName, _emailSettings.FromEmail));
                message.To.Add(MailboxAddress.Parse(emailOtp.EmailAddress));
                message.Subject = "Your OTP Code";
                message.Body = new TextPart("html")
                {
                    Text = $"<h1>OTP Code</h1><p>Your OTP code is: {otpCode}</p>"
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, SecureSocketOptions.SslOnConnect);
                    await client.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                _cache.Set(emailOtp.EmailAddress, otpCode, TimeSpan.FromMinutes(5));

                return OperationResult.SuccessResult(ResponseMessages.OtpSentSuccessfully);
            }
            catch (Exception)
            {
                return OperationResult.FailureResult(ResponseMessages.OtpSendingFailed);
            }
        }

        public Task<OperationResult> VerifyEmailOtp(EmailOtpVerificationDto otpVerification)
        {
            if (otpVerification == null || string.IsNullOrEmpty(otpVerification.EmailAddress) || string.IsNullOrEmpty(otpVerification.OtpCode))
            {
                return Task.FromResult(OperationResult.FailureResult(ResponseMessages.InvalidOtpData));
            }

            try
            {
                if (_cache.TryGetValue(otpVerification.EmailAddress, out string cachedOtp) && cachedOtp == otpVerification.OtpCode)
                {
                    return Task.FromResult(OperationResult.SuccessResult(ResponseMessages.OtpVerifiedSuccessfully));
                }
                else
                {
                    return Task.FromResult(OperationResult.FailureResult(ResponseMessages.OtpVerificationFailed));
                }
            }
            catch (Exception)
            {
                return Task.FromResult(OperationResult.FailureResult(ResponseMessages.OtpVerificationFailed));
            }
        }
    }
}
