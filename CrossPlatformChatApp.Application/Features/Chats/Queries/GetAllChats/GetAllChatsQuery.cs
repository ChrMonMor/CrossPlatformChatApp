using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Chats.Queries.GetAllChats {
    public class GetAllChatsQuery : IRequest<GetAllChatsResponse> {
    }
}
