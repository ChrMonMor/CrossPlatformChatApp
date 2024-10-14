using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Domain.Models;

namespace CrossPlatformChatApp.Persistence.Repositories {
    public class UserRepository(CrossPlatformChatAppDbContext dbContext) : BaseRepository<User>(dbContext), IUserRepository {
    }
}
