using AutoMapper;
using Registration.DTOS;
using Registration.Entity;

namespace Registration.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, UserEntity>();
            CreateMap<UserEntity, UserDto>();
        }
    }
}
