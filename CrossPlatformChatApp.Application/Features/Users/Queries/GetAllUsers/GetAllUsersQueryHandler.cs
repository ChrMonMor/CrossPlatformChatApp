using AutoMapper;
using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Application.Exceptions;
using CrossPlatformChatApp.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Users.Queries.GetAllUsers {
    public class GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper, ILogger<GetAllUsersQueryHandler> logger) : IRequestHandler<GetAllUsersQuery, GetAllUsersResponse> {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<GetAllUsersQueryHandler> _logger = logger;

        public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken) {

            var getAllUsersResponse = new GetAllUsersResponse();

            var validator = new GetAllUsersValidator(_userRepository);

            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (validatorResult.Errors.Count > 0) {

                string message = $"Validation failed: {validatorResult.Errors[0].ErrorMessage}";
                _logger.LogDebug(message);

                throw new ValidationException(validatorResult);
            }
            try {

                var getAllUsers = await _userRepository.ReadOnlyListAllAsync();

                if (getAllUsers is null) {
                    string message = $"No Users were found";
                    _logger.LogInformation(message);
                    throw new NotFoundException(nameof(User), request);
                }

                var allUsers = _mapper.Map<List<GetAllUsersVm>>(getAllUsers);

                getAllUsersResponse.Data = allUsers;

            } catch (Exception ex) {

                string message = $"Attempt to fetch users - {ex.Message}";
                _logger.LogError(message);

            }

            return getAllUsersResponse;

        }
    }
}
