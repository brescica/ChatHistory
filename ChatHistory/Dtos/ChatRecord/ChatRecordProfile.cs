using AutoMapper;

namespace ChatHistory.API.Dtos.ChatRecord
{
    public class ChatRecordProfile : Profile
    {
        public ChatRecordProfile()
        {
            CreateMap<Domain.Entities.ChatRecord, ChatRecordDto>();
        }

    }
}
