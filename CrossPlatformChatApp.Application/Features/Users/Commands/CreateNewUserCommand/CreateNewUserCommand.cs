using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Users.Commands.CreateNewUserCommand {
    public class CreateNewUserCommand : IRequest<CreateNewUserCommandResponse> {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string Image { get; set; } = string.Empty;
        public List<Guid> Friends { get; set; } = [];
        public List<Guid> Chats { get; set; } = [];
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Edited { get; set; } = DateTime.Now;
    }
}
