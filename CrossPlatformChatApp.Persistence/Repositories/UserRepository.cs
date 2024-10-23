using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using SharpCompress.Common;

namespace CrossPlatformChatApp.Persistence.Repositories {
    public class UserRepository(CrossPlatformChatAppDbContext dbContext) : BaseRepository<User>(dbContext), IUserRepository {
        public Task<User> AddChat(Guid id, Guid chat) {
            throw new NotImplementedException();
        }

        public Task<User> AddFriend(Guid id, Guid friend) {
            throw new NotImplementedException();
        }

        public Task ForgotPassword(string email) {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllFriendsDetails(List<Guid> friends) {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmail(string email) {
            throw new NotImplementedException();
        }

        public async Task<User> LoginAsync(string email, string password) {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public Task LogOut(Guid id) {
            throw new NotImplementedException();
        }

        public async Task<User> RegisterUser(string email, string password, string? name = null, string? image = null) {
            name ??= email;
            image ??= "none";
            var entity = new User() { Name = name, Email = email, Password = password, Image = image};
            await _dbContext.Set<User>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public Task RemoveChat(Guid id, Guid chat) {
            throw new NotImplementedException();
        }

        public Task RemoveFriend(Guid id, Guid friend) {
            throw new NotImplementedException();
        }
    }
}
