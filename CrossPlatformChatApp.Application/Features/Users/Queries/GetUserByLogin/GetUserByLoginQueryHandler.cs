using AutoMapper;
using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Application.Exceptions;
using CrossPlatformChatApp.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CrossPlatformChatApp.Application.Features.Users.Queries.GetUserByLogin {
    public class GetUserByLoginQueryHandler(IUserRepository userRepository, IMapper mapper, ILogger<GetUserByLoginQueryHandler> logger) : IRequestHandler<GetUserByLoginQuery, GetUserByLoginResponse> {
        private readonly IUserRepository _userRepository = userRepository;
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

                var userByLogin = _mapper.Map<UserByLoginVm>(getUserByLogin);

                getUserByLoginResponse.UserVm = userByLogin;

            } catch (Exception ex) {

                string message = $"Attempt to login into account ({request.Email}) failed do to error with database - {ex.Message}";
                _logger.LogError(message);

            }

            return getUserByLoginResponse;
        }
    }
}
