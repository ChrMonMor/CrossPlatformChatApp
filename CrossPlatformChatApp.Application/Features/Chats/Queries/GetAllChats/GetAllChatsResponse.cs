using CrossPlatformChatApp.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Chats.Queries.GetAllChats {
    public class GetAllChatsResponse : BaseResponse {
        public List<GetAllChatsVm> Data { get; set; } = [];
        public GetAllChatsResponse() : base() { }
    }
}
