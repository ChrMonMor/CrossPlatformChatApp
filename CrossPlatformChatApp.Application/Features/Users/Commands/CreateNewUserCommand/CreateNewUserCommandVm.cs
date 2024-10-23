using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Users.Commands.CreateNewUserCommand {
    public class CreateNewUserCommandVm {
        public Guid Id { get; set; }
        public string? Name { get; set; } 
        public string? Email { get; set; } 
        public string? Password { get; set; }
        public string? Image { get; set; }
        public List<Guid>? Friends { get; set; }
        public List<Guid>? Chats { get; set; } 
        public DateTime Created { get; set; } 
        public DateTime Edited { get; set; }
    }
}
