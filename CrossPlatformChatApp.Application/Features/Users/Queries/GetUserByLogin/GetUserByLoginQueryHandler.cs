using AutoMapper;
using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Application.Exceptions;
using CrossPlatformChatApp.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CrossPlatformChatApp.Application.Features.Users.Queries.GetUserByLogin {
    public class GetUserByLoginQueryHandler(IUserRepository userRepository, IChatRepository chatRepository, IMapper mapper, ILogger<GetUserByLoginQueryHandler> logger) : IRequestHandler<GetUserByLoginQuery, GetUserByLoginResponse> {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IChatRepository _chatRepository = chatRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<GetUserByLoginQueryHandler> _logger = logger;

        public async Task<GetUserByLoginResponse> Handle(GetUserByLoginQuery request, CancellationToken cancellationToken) {

            var getUserByLoginResponse = new GetUserByLoginResponse();

            var validator = new GetUserByLoginValidator(_userRepository);

            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (validatorResult.Errors.Count > 0) {

                string message = $"Validation failed: {validatorResult.Errors[0].ErrorMessage}";
                _logger.LogDebug(message);

                throw new ValidationException(validatorResult);
            }
            try {
                var getUserByLogin = await _userRepository.LoginAsync(request.Email, request.Password);

                if (getUserByLogin is null) {
                    string message = $"User ({request.Email}) provided the wrong Email or Password";
                    _logger.LogInformation(message);
                    throw new NotFoundException(nameof(User), request.Email);
                }


                var friends = await _userRepository.GetAllFriendsDetails(getUserByLogin.Friends);
                var chats =  await _chatRepository.GetUsersChatsDetails(getUserByLogin.Chats);

                var userByLogin = new UserByLoginVm();

                var friendsMap = _mapper.Map<List<UserByLoginAddOnVm>>(friends);
                var chatsMap = _mapper.Map<List<UserByLoginAddOnVm>>(chats);
                var userByLoginBase = _mapper.Map<UserByLoginBaseVm>(getUserByLogin);

                userByLogin.Friends = friendsMap;
                userByLogin.Chats = chatsMap;
                userByLogin.Email = userByLoginBase.Email;
                userByLogin.Id = userByLoginBase.Id;
                userByLogin.Image = userByLoginBase.Image;
                userByLogin.Name = userByLoginBase.Name;

                getUserByLoginResponse.Data = userByLogin;

            } catch (Exception ex) {

                string message = $"Attempt to login into account ({request.Email}) failed do to error with database - {ex.Message}";
                _logger.LogError(message);

            }

            return getUserByLoginResponse;
        }
    }
}
