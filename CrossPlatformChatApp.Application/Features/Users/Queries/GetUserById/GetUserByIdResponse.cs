using CrossPlatformChatApp.Application.Responses;

namespace CrossPlatformChatApp.Application.Features.Users.Queries.GetUserById {
    public class GetUserByIdResponse : BaseResponse {
        public UserByIdVm? Data { get; set; }

        public GetUserByIdResponse() : base() {
        }
    }
}
