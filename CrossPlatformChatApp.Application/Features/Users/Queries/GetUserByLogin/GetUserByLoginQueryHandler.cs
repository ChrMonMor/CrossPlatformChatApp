using AutoMapper;
using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Domain.Models;
using MediatR;

namespace CrossPlatformChatApp.Application.Features.Users.Queries.GetUserByLogin {
    public class GetUserByLoginQueryHandler : IRequestHandler<GetUserByLoginQuery, GetUserByLoginResponse> {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByLoginQueryHandler(IUserRepository userRepository, IMapper mapper) {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserByLoginResponse> Handle(GetUserByLoginQuery request, CancellationToken cancellationToken) {
            var getUserByLoginResponse = new GetUserByLoginResponse();
            var validator = new GetUserByLoginValidator(_userRepository);

            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (validatorResult.Errors.Count() > 0) { 
                getUserByLoginResponse.Success = false;
                getUserByLoginResponse.ValidationErrors = new List<string>();
                foreach (var error in validatorResult.Errors) {
                    getUserByLoginResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var getUserByLogin = await _userRepository.LoginAsync(request.Email, request.Email);
            var userByLogin = _mapper.Map<UserByLoginVm>(getUserByLogin);
            getUserByLoginResponse.UserVm = userByLogin;

            return getUserByLoginResponse;
        }
    }
}
