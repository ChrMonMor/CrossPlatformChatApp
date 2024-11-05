using CrossPlatformChatApp.Domain.Models;

namespace CrossPlatformChatApp.Application.Features.Chats.Queries.GetChatById {
    public class GetChatByIdBase {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> Members { get; set; }
        public List<Message> Messages { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
