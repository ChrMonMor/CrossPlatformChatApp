using AutoMapper;
using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Application.Exceptions;
using CrossPlatformChatApp.Application.Features.Users.Queries.GetUserById;
using CrossPlatformChatApp.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CrossPlatformChatApp.Application.Features.Chats.Queries.GetChatById {
    public class GetChatByIdQueryHandler(IChatRepository chatRepository, IUserRepository userRepository, IMapper mapper, ILogger<GetChatByIdQueryHandler> logger) : IRequestHandler<GetChatByIdQuery, GetChatByIdResponse> {
        private readonly IChatRepository _chatRepository = chatRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<GetChatByIdQueryHandler> _logger = logger;

        public async Task<GetChatByIdResponse> Handle(GetChatByIdQuery request, CancellationToken cancellationToken) {
            var getChatByIdResponse = new GetChatByIdResponse();

            var validator = new GetChatByIdValidator(_chatRepository);

            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (validatorResult.Errors.Count > 0) {

                string message = $"Validation failed: {validatorResult.Errors[0].ErrorMessage}";
                _logger.LogDebug(message);

                throw new ValidationException(validatorResult);
            }
            try {

                var getChatById = await _chatRepository.GetByIdAsync(request.Id);
                
                if (getChatById is null) {
                    string message = $"No chat were found";
                    _logger.LogInformation(message);
                    throw new NotFoundException(nameof(Chat), request);
                }

                GetChatByIdVm getChatByIdVm = new GetChatByIdVm();

                var getChatMembers = await _chatRepository.GetChatMembersDetails(getChatById.Members);
                var getUsers = await _userRepository.ReadOnlyListAllAsync();

                getChatByIdVm.Id = getChatById.Id;
                getChatByIdVm.Name = getChatById.Name;
                getChatByIdVm.Created = getChatById.Created;
                getChatByIdVm.Edited = getChatById.Edited;
                getChatByIdVm.Members = _mapper.Map<List<GetChatByIdAddOnUser>>(getChatMembers);

                getChatById.Messages = getChatById.Messages.Take(25*request.Count).ToList();

                List<GetChatByIdAddOnMessage> getChatByIdAddOnMessages = [];
                foreach (var message in getChatById.Messages) {
                    var user = getUsers.Where(x => x.Id == message.UserId).Single();
                    getChatByIdAddOnMessages.Add(new GetChatByIdAddOnMessage() {
                        Id = message.Id,
                        UserId = message.UserId,
                        UserName = user.Name,
                        UserImage = user.Image,
                        Text = message.Text,
                        IsImage = message.IsImage,
                        Created = message.Created,
                        Updated = message.Updated,
                    }); 
                }

                getChatByIdVm.Messages = getChatByIdAddOnMessages;

                getChatByIdResponse.Data = getChatByIdVm;

            } catch (Exception ex) {

                string message = $"Attempt to fetch chats - {ex.Message}";
                _logger.LogError(message);

            }

            return getChatByIdResponse;
        }
    }
}
