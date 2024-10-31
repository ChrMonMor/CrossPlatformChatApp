using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Domain.Models;

namespace CrossPlatformChatApp.Persistence.Repositories {
    public class ChatRepository(CrossPlatformChatAppDbContext dbContext) : BaseRepository<Chat>(dbContext), IChatRepository {
        public Task<Chat> GetChat(Guid chatId) {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetChatMembersDetails(List<Guid> members) {
            throw new NotImplementedException();
        }

        public Task<List<Chat>> GetUsersChatsDetails(List<Guid> chats) {
            throw new NotImplementedException();
        }

    }
}
