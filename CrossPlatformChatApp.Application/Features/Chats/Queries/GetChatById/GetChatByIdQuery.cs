using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Chats.Queries.GetChatById {
    public class GetChatByIdQuery : IRequest<GetChatByIdResponse> {
        public Guid Id { get; set; }
        public int Count { get; set; } = 1;  
    }
}
