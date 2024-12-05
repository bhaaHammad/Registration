using Registration.DTOS;
using Registration.Utilities;

namespace Registration.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<OperationResult> Login(LoginDto loginDto);
    }
}
