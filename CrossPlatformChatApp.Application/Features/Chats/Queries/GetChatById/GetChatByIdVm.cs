using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Chats.Queries.GetChatById {
    public class GetChatByIdVm {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<GetChatByIdAddOnUser> Members { get; set; }
        public List<GetChatByIdAddOnMessage> Messages { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
