using CrossPlatformChatApp.Application.Features.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrossPlatformChatApp.API.Controllers {
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController(IMediator mediator) : ControllerBase {
        private readonly IMediator _mediator = mediator;

        [HttpPost(Name = "GetUserById")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserByIdVm>> GetUserById([FromBody] GetUserByIdQuery getUserByIdQuery) {
            var response = await _mediator.Send(getUserByIdQuery);
            return Ok(response);
        }

    }
}
