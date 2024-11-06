using CrossPlatformChatApp.Application.Responses;
using System;

namespace CrossPlatformChatApp.Application.Features.Users.Queries.GetAllUsers {
    public class GetAllUsersResponse : BaseResponse {
        public List<GetAllUsersVm>? Data { get; set; }
        public GetAllUsersResponse() : base() { }
    }
}
