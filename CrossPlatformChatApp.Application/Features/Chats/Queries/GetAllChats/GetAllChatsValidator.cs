using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Application.Features.Users.Queries.GetUserById;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Chats.Queries.GetAllChats {
    public class GetAllChatsValidator : AbstractValidator<GetAllChatsQuery> {
        private readonly IChatRepository _chatRepository;

        public GetAllChatsValidator(IChatRepository chatRepository) {
            _chatRepository = chatRepository;
        }
    }
}
