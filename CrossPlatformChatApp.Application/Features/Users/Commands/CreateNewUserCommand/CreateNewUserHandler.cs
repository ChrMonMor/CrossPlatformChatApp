using AutoMapper;
using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Application.Exceptions;
using CrossPlatformChatApp.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CrossPlatformChatApp.Application.Features.Users.Commands.CreateNewUserCommand {
    public class CreateNewUserHandler(IUserRepository userRepository, IMapper mapper, ILogger<CreateNewUserHandler> logger) : IRequestHandler<CreateNewUserCommand, CreateNewUserCommandResponse> {

        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<CreateNewUserHandler> _logger = logger;

        public async Task<CreateNewUserCommandResponse> Handle(CreateNewUserCommand request, CancellationToken cancellationToken) {

            var createNewUserResponse = new CreateNewUserCommandResponse();
            var validator = new CreateNewUserValidator(_userRepository);

            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (validatorResult.Errors.Count > 0) {

                throw new ValidationException(validatorResult);

            } else {

                var newUser = await _userRepository.RegisterUser(request.Email, request.Password, request.Name, request.ImageAdress);

                try {

                    createNewUserResponse.NewUser = _mapper.Map<CreateNewUserCommandVm>(newUser);

                } catch (Exception ex) {

                    string message = $"User {request.Email} did not get registered- {request} - {ex.Message}";
                    _logger.LogError(message);

                }
            }
            return createNewUserResponse;
        }
    }
}
