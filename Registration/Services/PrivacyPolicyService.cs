using AutoMapper;
using Registration.DTOS;
using Registration.Entity;
using Registration.Interfaces;
using Registration.Utilities;

namespace Registration.Services
{
    public class PrivacyPolicyService : IPrivacyPolicyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PrivacyPolicyService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OperationResult> AcceptPolicy(PrivacyPolicyDto privacyPolicyDto)
        {
            if (privacyPolicyDto == null)
            {
                return OperationResult.FailureResult(ResponseMessages.InvalidData);
            }

            var isAccepted = _context.PrivacyPolicies.FirstOrDefault(x => x.UserId == privacyPolicyDto.UserId);
            if (isAccepted != null)
            {
                return await UpdatePolicyAsync(isAccepted, privacyPolicyDto);
            }

            return await AddNewPolicyAsync(privacyPolicyDto);
        }

        private async Task<OperationResult> UpdatePolicyAsync(PrivacyPolicyEntity existingEntity, PrivacyPolicyDto privacyPolicyDto)
        {
            var updatedEntity = CreatePrivacyPolicyEntity(privacyPolicyDto);
            _mapper.Map(updatedEntity, existingEntity);
            existingEntity.AcceptedDate = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
                return OperationResult.SuccessResult(ResponseMessages.PolicyUpdatedSuccessfully);
            }
            catch (Exception)
            {
                return OperationResult.FailureResult(ResponseMessages.PolicyAcceptanceFailed);
            }
        }

        private async Task<OperationResult> AddNewPolicyAsync(PrivacyPolicyDto privacyPolicyDto)
        {
            try
            {
                var privacyPolicyEntity = CreatePrivacyPolicyEntity(privacyPolicyDto);
                await _context.PrivacyPolicies.AddAsync(privacyPolicyEntity);
                await _context.SaveChangesAsync();
                return OperationResult.SuccessResult(ResponseMessages.PolicyAcceptedSuccessfully);
            }
            catch (Exception)
            {
                return OperationResult.FailureResult(ResponseMessages.PolicyAcceptanceFailed);
            }
        }

        private PrivacyPolicyEntity CreatePrivacyPolicyEntity(PrivacyPolicyDto privacyPolicyDto)
        {
            var entity = _mapper.Map<PrivacyPolicyEntity>(privacyPolicyDto);
            entity.AcceptedDate = DateTime.UtcNow;
            return entity;
        }
    }
}
