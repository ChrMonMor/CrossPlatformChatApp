using AutoMapper;
using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Application.Exceptions;
using CrossPlatformChatApp.Application.Features.Users.Queries.GetUserById;
using CrossPlatformChatApp.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CrossPlatformChatApp.Application.Features.Chats.Queries.GetAllChats {
    public class GetAllChatsQueryHandler(IChatRepository chatRepository, IUserRepository userRepository, IMapper mapper, ILogger<GetAllChatsQueryHandler> logger) : IRequestHandler<GetAllChatsQuery, GetAllChatsResponse> {
        private readonly IChatRepository _chatRepository = chatRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<GetAllChatsQueryHandler> _logger = logger;

        public async Task<GetAllChatsResponse> Handle(GetAllChatsQuery request, CancellationToken cancellationToken) {
            var getAllChatsResponse = new GetAllChatsResponse();

            var validator = new GetAllChatsValidator(_chatRepository);

            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (validatorResult.Errors.Count > 0) {

                string message = $"Validation failed: {validatorResult.Errors[0].ErrorMessage}";
                _logger.LogDebug(message);

                throw new ValidationException(validatorResult);
            }
            try {

                var getAllChats = await _chatRepository.ReadOnlyListAllAsync();
                
                if (getAllChats is null) {
                    string message = $"No chats were found";
                    _logger.LogInformation(message);
                    throw new NotFoundException(nameof(Chat), request);
                }

                var allChats = _mapper.Map<List<GetAllChatsVm>>(getAllChats);

                getAllChatsResponse.Data = allChats;

            } catch (Exception ex) {

                string message = $"Attempt to fetch chats - {ex.Message}";
                _logger.LogError(message);

            }

            return getAllChatsResponse;
        }
    }
}
