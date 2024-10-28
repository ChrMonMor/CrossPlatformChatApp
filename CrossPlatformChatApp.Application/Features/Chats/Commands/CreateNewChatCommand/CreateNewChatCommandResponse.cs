using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Chats.Commands.CreateNewChatCommand {
    public class CreateNewChatCommandResponse {
        public CreateNewChatCommandVm Data { get; set; }
        public CreateNewChatCommandResponse() : base() { }
    }
}
