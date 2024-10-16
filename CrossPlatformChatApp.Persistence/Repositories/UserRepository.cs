using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CrossPlatformChatApp.Persistence.Repositories {
    public class UserRepository(CrossPlatformChatAppDbContext dbContext) : BaseRepository<User>(dbContext), IUserRepository {
        public async Task<User?> GetUserByEmail(string email) {
            return (await _dbContext.Set<User>().ToListAsync()).FirstOrDefault(x => x.Email == email);
        }

        public async Task<User?> LoginAsync(string email, string password) {
            var users = await _dbContext.Set<User>().ToListAsync();
            return users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
