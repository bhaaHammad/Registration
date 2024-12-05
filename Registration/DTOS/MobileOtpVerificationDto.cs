namespace Registration.DTOS
{
    public class MobileOtpVerificationDto
    {
        public required string PhoneNumber { get; set; }
        public string? Otp { get; set; }
    }
}
