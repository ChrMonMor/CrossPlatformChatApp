using CrossPlatformChatApp.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Users.Queries.GetUserById {
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery> {
        private readonly IUserRepository _userRepository;
        public GetUserByIdValidator(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
    }
}
