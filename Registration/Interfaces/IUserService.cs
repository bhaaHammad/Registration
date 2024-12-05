using Registration.DTOS;
using Registration.Utilities;

namespace Registration.Interfaces
{
    public interface IUserService
    {
        public Task<OperationResult> Register(UserDto user);
        public Task<OperationResult> AddPin(PinDto addPinDto);
        public Task<OperationResult> VerifyPin(PinDto verifyPinDto);
        public Task<OperationResult> EnableBiometrics(EnableBiometricsDto enableBiometricsDto);
        public Task<OperationResult> SaveBiometrics(SaveBiometricsDto saveBiometricsDto);

    }
}
