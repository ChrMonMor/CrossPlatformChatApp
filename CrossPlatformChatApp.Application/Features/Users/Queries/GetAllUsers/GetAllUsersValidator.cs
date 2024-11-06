using CrossPlatformChatApp.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Users.Queries.GetAllUsers {
    public class GetAllUsersValidator : AbstractValidator<GetAllUsersQuery> {
        private readonly IUserRepository _userRepository;

        public GetAllUsersValidator(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
    }
}
