using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Users.Commands.CreateNewUserCommand {
    public class CreateNewUserCommand : IRequest<CreateNewUserCommandResponse> {
        public required string Email { get; set; } 
        public required string Password { get; set; } 
        public string? Name { get; set; }
        public string? ImageAdress { get; set; }
    }
}
