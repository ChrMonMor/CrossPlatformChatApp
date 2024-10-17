using AutoMapper;
using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Application.Exceptions;
using CrossPlatformChatApp.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CrossPlatformChatApp.Application.Features.Users.Commands.CreateNewUserCommand {
    public class CreateNewUserHandler : IRequestHandler<CreateNewUserCommand, CreateNewUserCommandResponse> {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateNewUserHandler> _logger;

        public CreateNewUserHandler(IUserRepository userRepository, IMapper mapper, ILogger<CreateNewUserHandler> logger) {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateNewUserCommandResponse> Handle(CreateNewUserCommand request, CancellationToken cancellationToken) {

            var createNewUserResponse = new CreateNewUserCommandResponse();
            var validator = new CreateNewUserValidator(_userRepository);

            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count() > 0) {

                throw new ValidationException(validatorResult);

            } else {
                var newUser = _mapper.Map<User>(request);

                try {
                    newUser = await _userRepository.AddAsync(newUser);
                    createNewUserResponse.NewUser = _mapper.Map<CreateNewUserCommand>(newUser);

                } catch (Exception ex) {
                    _logger.LogError($"User {request.Email} did not get registered- {request.ToString()} - {ex.Message}");
                }
            }
            return createNewUserResponse;
        }
    }
}
