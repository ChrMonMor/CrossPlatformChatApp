using CrossPlatformChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Chats.Queries.GetAllChats {
    public class GetAllChatsVm {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> Members { get; set; }
        public List<Message> Messages { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
