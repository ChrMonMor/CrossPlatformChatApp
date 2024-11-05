using CrossPlatformChatApp.Application.Features.Chats.Commands.CreateNewChatCommand;
using CrossPlatformChatApp.Application.Features.Chats.Queries.GetAllChats;
using CrossPlatformChatApp.Application.Features.Chats.Queries.GetChatById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrossPlatformChatApp.API.Controllers {
    [Route("[controller]/[action]")]
    [ApiController]
    public class ChatController(IMediator mediator) : ControllerBase {
        private readonly IMediator _mediator = mediator;

        [HttpPost(Name = "CreateNew")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateNewChatCommand>> CreateNew([FromBody] CreateNewChatCommand createNewChatCommand) {
            var response = await _mediator.Send(createNewChatCommand);
            return Ok(response);
        }
        [HttpPost(Name = "GetAllChats")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetAllChatsVm>> GetAll() {
            var respone = await _mediator.Send(new GetAllChatsQuery());
            return Ok(respone);
        }
        [HttpPost(Name = "GetById")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GetChatByIdVm>> GetById([FromBody] GetChatByIdQuery getChatByIdQuery) {
            var respone = await _mediator.Send(getChatByIdQuery);
            return Ok(respone);
        }
    }
}
