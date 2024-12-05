using Registration.DTOS;
using Registration.Utilities;

namespace Registration.Interfaces
{
    public interface IPrivacyPolicyService
    {
        public Task<OperationResult> AcceptPolicy(PrivacyPolicyDto privacyPolicyDto);
    }
}
