using CrossPlatformChatApp.Application.Features.Users.Commands.CreateNewUserCommand;
using CrossPlatformChatApp.Application.Features.Users.Queries.GetUserByLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrossPlatformChatApp.API.Controllers {
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase {
        private readonly IMediator _mediator = mediator;

        [HttpPost(Name = "Login")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserByLoginVm>> Login([FromBody] GetUserByLoginQuery getUserByLoginQuery) {
            var response = await _mediator.Send(getUserByLoginQuery);
            return Ok(response);
        }

        [HttpPost(Name = "SignUp")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateNewUserCommand>> SignUp([FromBody] CreateNewUserCommand createNewUserCommand) {
            var response = await _mediator.Send(createNewUserCommand);
            return Ok(response);
        }
    }
}
