using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Domain.Models;

namespace CrossPlatformChatApp.Persistence.Repositories {
    public class ChatRepository(CrossPlatformChatAppDbContext dbContext) : BaseRepository<Chat>(dbContext), IChatRepository {
    }
}
