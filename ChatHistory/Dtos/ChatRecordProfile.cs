using AutoMapper;
using ChatHistory.Domain.Entities;

namespace ChatHistory.API.Dtos
{
    public class ChatRecordProfile : Profile
    {
        public ChatRecordProfile()
        {
            CreateMap<ChatRecord, ChatRecordDto>();
        }
        
    }
}
