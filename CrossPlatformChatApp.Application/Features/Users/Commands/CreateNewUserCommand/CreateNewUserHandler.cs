using AutoMapper;
using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Users.Commands.CreateNewUserCommand {
    public class CreateNewUserHandler : IRequestHandler<CreateNewUserCommand, CreateNewUserCommandResponse> {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateNewUserHandler(IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateNewUserCommandResponse> Handle(CreateNewUserCommand request, CancellationToken cancellationToken) {
            var createNewUserResponse = new CreateNewUserCommandResponse();
            var validator = new CreateNewUserValidator(_userRepository);

            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count() > 0)
            {
                createNewUserResponse.Success = false;

                foreach (var error in validatorResult.Errors)
                {
                    createNewUserResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            } else {
                var newUser = _mapper.Map<User>(request);
                newUser = await _userRepository.AddAsync(newUser);
                createNewUserResponse.NewUser = _mapper.Map<CreateNewUserCommand>(newUser);
            }
            return createNewUserResponse;
        }
    }
}
