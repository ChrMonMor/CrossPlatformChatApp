using CrossPlatformChatApp.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Messages.Commands.SendMessageCommand {
    public class SendMessageValidator : AbstractValidator<SendMessageCommand> {
        private readonly IMessageRepository _messageRepository;

        public SendMessageValidator(IMessageRepository messageRepository) {
            _messageRepository = messageRepository;

            RuleFor(x => x.Message).NotEmpty();
        }
    }
}
