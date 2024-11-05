using CrossPlatformChatApp.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Chats.Queries.GetChatById {
    public class GetChatByIdValidator : AbstractValidator<GetChatByIdQuery> {
        private readonly IChatRepository _chatRepository;

        public GetChatByIdValidator(IChatRepository chatRepository) {
            _chatRepository = chatRepository;
        }
    }
}
