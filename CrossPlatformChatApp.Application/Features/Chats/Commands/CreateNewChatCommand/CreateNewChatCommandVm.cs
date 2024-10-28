using CrossPlatformChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Chats.Commands.CreateNewChatCommand {
    public class CreateNewChatCommandVm {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public List<Guid> Members { get; set; } = [];
        public List<Message> Messages { get; set; } = [];
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Edited { get; set; }
    }
}
