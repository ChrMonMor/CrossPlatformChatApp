using CrossPlatformChatApp.Application.Features.Users.Commands.CreateNewUserCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Messages.Commands.SendMessageCommand {
    public class SendMessageCommand : IRequest<SendMessageCommandResponse> {
        public Guid Sender { get; set; }
        public Guid ChatId { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsImage { get; set; } = false;
    }
}
