using Registration.DTOS;
using Registration.Interfaces;
using Registration.Utilities;

namespace Registration.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApplicationDbContext _context;

        public AuthenticationService(ApplicationDbContext context)
        {
             _context = context;
        }

        public Task<OperationResult> Login(LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.IcNumber))
            {
                return Task.FromResult(OperationResult.FailureResult(ResponseMessages.InvalidUserData));
            }

            var user = _context.Users.FirstOrDefault(x => x.IcNumber == loginDto.IcNumber);
            if (user == null)
            {
                return Task.FromResult(OperationResult.FailureResult(ResponseMessages.UserNotFound));
            }

            return Task.FromResult(OperationResult.SuccessResult(ResponseMessages.LoginSuccessful));
        }
    }
}
