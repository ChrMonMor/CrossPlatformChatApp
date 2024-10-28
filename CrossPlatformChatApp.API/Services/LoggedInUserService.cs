using CrossPlatformChatApp.Application.Contracts;
using System.Security.Claims;

namespace CrossPlatformChatApp.API.Services {
    public class LoggedInUserService : ILoggedInUserService {
        private readonly IHttpContextAccessor _contextAccessor;
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor) {
            _contextAccessor = httpContextAccessor;
        }

        public string UserId {
            get {
                return _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            }
        }
    }
}
