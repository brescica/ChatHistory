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

        /// inject mediator
        public ChatHistoryController(IMediator mediator)
        {
            _mediator = mediator;
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
            return Ok(await _mediator.Send(query));
        }
    }
}
