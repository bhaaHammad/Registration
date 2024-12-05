namespace Registration.DTOS
{
    public class EmailOtpVerificationDto
    {
        public required string EmailAddress { get; set; }
        public string? OtpCode { get; set; }
    }
}
