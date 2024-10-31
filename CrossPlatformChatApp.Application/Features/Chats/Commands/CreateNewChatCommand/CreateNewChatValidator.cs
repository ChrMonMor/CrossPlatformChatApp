using CrossPlatformChatApp.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Chats.Commands.CreateNewChatCommand {
    public class CreateNewChatValidator : AbstractValidator<CreateNewChatCommand>  {
        private readonly IChatRepository _chatRepository;
        public CreateNewChatValidator(IChatRepository chatRepository) {
            _chatRepository = chatRepository;
        }
    }
}
