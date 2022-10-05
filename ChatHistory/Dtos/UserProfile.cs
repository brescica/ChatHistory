using AutoMapper;
using ChatHistory.Domain.Entities;

namespace ChatHistory.API.Dtos
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
