namespace Registration.Utilities
{
    public class ResponseMessages
    {
        public const string DatabaseError = "An error occurred while processing your request.";
        public const string InvalidData = "Invalid data provided.";

        public const string UserRegisteredSuccessfully = "User registered successfully.";
        public const string UserRegistrationFailed = "User registration failed.";
        public const string InvalidUserData = "Invalid user data.";
        public const string UserAlreadyExists = "A user with the provided information already exists.";

        public const string InvalidOtpRequest = "Invalid OTP request.";
        public const string OtpGeneratedSuccessfully = "OTP generated successfully.";
        public const string OtpResentSuccessfully = "OTP resent successfully.";
        public const string OtpVerifiedSuccessfully = "OTP verified successfully.";
        public const string OtpExpired = "OTP has expired.";
        public const string InvalidOtp = "Invalid OTP.";

        public const string InvalidOtpData = "Invalid OTP data provided.";
        public const string OtpSentSuccessfully = "OTP sent successfully.";
        public const string OtpSendingFailed = "Failed to send OTP.";
        public const string OtpVerificationFailed = "OTP verification failed.";

        public const string PolicyAlreadyAccepted = "Privacy policy has already been accepted.";
        public const string PolicyAcceptedSuccessfully = "Privacy policy accepted successfully.";
        public const string PolicyAcceptanceFailed = "Failed to accept privacy policy.";
        public const string PolicyUpdatedSuccessfully = "The policy acceptance date has been updated successfully.";

        public const string InvalidPinData = "Invalid PIN data.";
        public const string UserNotFound = "User not found.";
        public const string PinAddedSuccessfully = "PIN added successfully.";
        public const string PinAdditionFailed = "Failed to add PIN.";
        public const string InvalidPin = "Invalid PIN.";
        public const string PinVerifiedSuccessfully = "PIN verified successfully.";

        public const string BiometricsEnabledSuccessfully = "Biometrics enabled successfully.";
        public const string BiometricsEnableFailed = "Failed to enable biometrics.";
        public const string BiometricsSavedSuccessfully = "Biometrics saved successfully.";
        public const string BiometricsSaveFailed = "Failed to save biometrics.";

        public const string LoginSuccessful = "Login successful.";
    }
}
