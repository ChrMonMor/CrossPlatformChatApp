using CrossPlatformChatApp.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Chats.Queries.GetChatById {
    public class GetChatByIdResponse : BaseResponse {
        public GetChatByIdVm? Data { get; set; }
        public GetChatByIdResponse() : base() { }
    }
}
