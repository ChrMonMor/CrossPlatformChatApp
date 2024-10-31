using AutoMapper;
using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Application.Exceptions;
using CrossPlatformChatApp.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CrossPlatformChatApp.Application.Features.Users.Queries.GetUserById {
    public class GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper, ILogger<GetUserByIdQueryHandler> logger) : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse> {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<GetUserByIdQueryHandler> _logger = logger;

        public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) {

            var getUserByIdResponse = new GetUserByIdResponse();

            var validator = new GetUserByIdValidator(_userRepository);

            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (validatorResult.Errors.Count > 0) {

                string message = $"Validation failed: {validatorResult.Errors[0].ErrorMessage}";
                _logger.LogDebug(message);

                throw new ValidationException(validatorResult);
            }
            try {
                var getUserById = await _userRepository.GetByIdAsync(request.Id);

                if (getUserById is null) {
                    string message = $"User ({request.Id}) was not found";
                    _logger.LogInformation(message);
                    throw new NotFoundException(nameof(User), request.Id);
                }

                var userById = _mapper.Map<UserByIdVm>(getUserById);

                getUserByIdResponse.Data = userById;

            } catch (Exception ex) {

                string message = $"Attempt to fetch account ID: ({request.Id}) - {ex.Message}";
                _logger.LogError(message);

            }

            return getUserByIdResponse;
        }
    }
}
