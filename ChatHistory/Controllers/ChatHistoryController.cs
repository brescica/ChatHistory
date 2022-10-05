using AutoMapper;
using ChatHistory.API.Dtos;
using ChatHistory.Application.ChatHistory.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatHistory.API.Controllers
{
    /// <summary>
    /// Controller for fetching chat records
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ChatHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// inject mediator
        public ChatHistoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        /// <summary>
        /// Gets chat records
        /// </summary>
        /// <returns>Chat records</returns>
        /// <response code="200">Returns the ChatRecords filtered by search criteria</response>
        [HttpGet(Name = "GetChatHistory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetChatHistory([FromQuery] GetChatHistoryQuery query)
        {
            return Ok(_mapper.Map<IEnumerable<ChatRecordDto>>(await _mediator.Send(query)));
        }
    }
}
