using CrossPlatformChatApp.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Users.Queries.GetUserByLogin {
    public class GetUserByLoginResponse : BaseResponse {
        public UserByLoginVm? Data { get; set; }

        public GetUserByLoginResponse() : base() {
        }
    }
}
