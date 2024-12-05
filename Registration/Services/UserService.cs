using AutoMapper;
using Registration.DTOS;
using Registration.Entity;
using Registration.Interfaces;
using Registration.Utilities;

namespace Registration.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context,
                           IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OperationResult> Register(UserDto user)
        {

            if (user == null)
            {
                return OperationResult.FailureResult(ResponseMessages.InvalidUserData);
            }

            var isExist = _context.Users.FirstOrDefault(x => x.EmailAddress == user.EmailAddress);
            if (isExist != null)
            {
                return OperationResult.FailureResult(ResponseMessages.UserAlreadyExists);
            }

            try
            {
                var userEntity = _mapper.Map<UserEntity>(user);
                await _context.Users.AddAsync(userEntity);
                await _context.SaveChangesAsync();
                return OperationResult.SuccessResult(ResponseMessages.UserRegisteredSuccessfully);
            }
            catch (Exception)
            {
                return OperationResult.FailureResult(ResponseMessages.UserRegistrationFailed);
            }
        }

        public async Task<OperationResult> AddPin(PinDto addPinDto)
        {
            if (addPinDto == null || string.IsNullOrEmpty(addPinDto.Pin) || addPinDto.Pin.Length != 6)
            {
                return OperationResult.FailureResult(ResponseMessages.InvalidPinData);
            }

            var user = _context.Users.FirstOrDefault(x => x.Id == addPinDto.UserId);
            if (user == null)
            {
                return OperationResult.FailureResult(ResponseMessages.UserNotFound);
            }

            try
            {
                user.Pin = addPinDto.Pin;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return OperationResult.SuccessResult(ResponseMessages.PinAddedSuccessfully);
            }
            catch (Exception)
            {
                return OperationResult.FailureResult(ResponseMessages.PinAdditionFailed);
            }
        }

        public Task<OperationResult> VerifyPin(PinDto verifyPinDto)
        {
            if (verifyPinDto == null || string.IsNullOrEmpty(verifyPinDto.Pin) || verifyPinDto.Pin.Length != 6)
            {
                return Task.FromResult(OperationResult.FailureResult(ResponseMessages.InvalidPinData));
            }

            var user = _context.Users.FirstOrDefault(x => x.Id == verifyPinDto.UserId);
            if (user == null)
            {
                return Task.FromResult(OperationResult.FailureResult(ResponseMessages.UserNotFound));
            }

            if (user.Pin != verifyPinDto.Pin)
            {
                return Task.FromResult(OperationResult.FailureResult(ResponseMessages.InvalidPin));
            }

            return Task.FromResult(OperationResult.SuccessResult(ResponseMessages.PinVerifiedSuccessfully));
        }

        public async Task<OperationResult> EnableBiometrics(EnableBiometricsDto enableBiometricsDto)
        {
            if (enableBiometricsDto == null || enableBiometricsDto.UserId <= 0)
            {
                return OperationResult.FailureResult(ResponseMessages.InvalidUserData);
            }

            var user = _context.Users.FirstOrDefault(x => x.Id == enableBiometricsDto.UserId);
            if (user == null)
            {
                return OperationResult.FailureResult(ResponseMessages.UserNotFound);
            }

            try
            {
                user.BiometricsEnabled = true;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return OperationResult.SuccessResult(ResponseMessages.BiometricsEnabledSuccessfully);
            }
            catch (Exception)
            {
                return OperationResult.FailureResult(ResponseMessages.BiometricsEnableFailed);
            }
        }

        public async Task<OperationResult> SaveBiometrics(SaveBiometricsDto saveBiometricsDto)
        {
            if (saveBiometricsDto == null || saveBiometricsDto.UserId <= 0 || string.IsNullOrEmpty(saveBiometricsDto.BiometricsData))
            {
                return OperationResult.FailureResult(ResponseMessages.InvalidUserData);
            }

            var user = _context.Users.FirstOrDefault(x => x.Id == saveBiometricsDto.UserId);
            if (user == null)
            {
                return OperationResult.FailureResult(ResponseMessages.UserNotFound);
            }

            try
            {
                user.BiometricsData = saveBiometricsDto.BiometricsData;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return OperationResult.SuccessResult(ResponseMessages.BiometricsSavedSuccessfully);
            }
            catch (Exception)
            {
                return OperationResult.FailureResult(ResponseMessages.BiometricsSaveFailed);
            }
        }
    }
}
