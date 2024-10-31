using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Chats.Commands.CreateNewChatCommand {
    public class CreateNewChatCommand: IRequest<CreateNewChatCommandResponse> {
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public Guid? FriendId { get; set; }
        public string? Message { get; set; }
    }
}
