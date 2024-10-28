using AutoMapper;
using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Application.Features.Messages.Commands.SendMessageCommand;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Chats.Commands.CreateNewChatCommand {
    public class CreateNewChatHandler(IChatRepository chatRepository, IMapper mapper, ILogger<CreateNewChatHandler> logger) : IRequestHandler<CreateNewChatCommand, CreateNewChatCommandResponse> {
        private readonly IChatRepository _chatRepository = chatRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<CreateNewChatHandler> _logger = logger;

        public Task<CreateNewChatCommandResponse> Handle(CreateNewChatCommand request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}
