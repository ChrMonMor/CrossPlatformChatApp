using CrossPlatformChatApp.Application.Features.Messages.Commands.SendMessageCommand;
using CrossPlatformChatApp.Application.Features.Users.Commands.CreateNewUserCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrossPlatformChatApp.API.Controllers {
    [Route("[controller]/[action]")]
    [ApiController]
    public class MessageController(IMediator mediator) : ControllerBase {
        private readonly IMediator _mediator = mediator;
        [HttpPost(Name = "SendMessage")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SendMessageCommandVm>> SendMessage([FromBody] SendMessageCommand createNewUserCommand) {
            var response = await _mediator.Send(createNewUserCommand);
            return Ok(response);
        }
    }
}
