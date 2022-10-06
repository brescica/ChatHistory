using AutoMapper;

namespace ChatHistory.API.Dtos.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.Entities.User, UserDto>();
        }
    }
}
