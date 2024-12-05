using AutoMapper;
using Registration.DTOS;
using Registration.Entity;

namespace Registration.Mappings
{
    public class PrivacyPolicyProfile : Profile
    {
        public PrivacyPolicyProfile() 
        {
            CreateMap<PrivacyPolicyDto, PrivacyPolicyEntity>();
            CreateMap<PrivacyPolicyEntity, PrivacyPolicyDto>();
        }
    }
}
