using CrossPlatformChatApp.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Users.Queries.GetUserByLogin {
    public class GetUserByLoginValidator : AbstractValidator<GetUserByLoginQuery> {
        private readonly IUserRepository _userRepository;
        public GetUserByLoginValidator(IUserRepository userRepository) {
            _userRepository = userRepository;
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} is not a valid email");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
