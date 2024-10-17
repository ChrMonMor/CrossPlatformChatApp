using AutoMapper;
using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Application.Exceptions;
using CrossPlatformChatApp.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CrossPlatformChatApp.Application.Features.Users.Queries.GetUserByLogin {
    public class GetUserByLoginQueryHandler : IRequestHandler<GetUserByLoginQuery, GetUserByLoginResponse> {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserByLoginQueryHandler> _logger;

        public GetUserByLoginQueryHandler(IUserRepository userRepository, IMapper mapper, ILogger<GetUserByLoginQueryHandler> logger) {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetUserByLoginResponse> Handle(GetUserByLoginQuery request, CancellationToken cancellationToken) {
            var getUserByLoginResponse = new GetUserByLoginResponse();
            var validator = new GetUserByLoginValidator(_userRepository);

            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (validatorResult.Errors.Count() > 0) {
                throw new ValidationException(validatorResult);
            }
            try {
                var getUserByLogin = await _userRepository.LoginAsync(request.Email, request.Password);
                if (getUserByLogin is null) {
                    throw new NotFoundException(nameof(User), request.Email);
                }

                var userByLogin = _mapper.Map<UserByLoginVm>(getUserByLogin);
                getUserByLoginResponse.UserVm = userByLogin;
            } catch (Exception ex) {
                _logger.LogError($"Attempt to login into account {request.Email} failed do to error with database - {ex.Message}");
            }

            return getUserByLoginResponse;
        }
    }
}
