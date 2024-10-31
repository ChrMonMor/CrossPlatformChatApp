using AutoMapper;
using CrossPlatformChatApp.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Chats.Queries.GetAllChats {
    public class GetAllChatsQueryHandler(IChatRepository chatRepository, IMapper mapper, ILogger<GetAllChatsQueryHandler> logger) : IRequestHandler<GetAllChatsQuery, GetAllChatsResponse> {
        private readonly IChatRepository _chatRepository = chatRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<GetAllChatsQueryHandler> _logger = logger;

        public Task<GetAllChatsResponse> Handle(GetAllChatsQuery request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}
