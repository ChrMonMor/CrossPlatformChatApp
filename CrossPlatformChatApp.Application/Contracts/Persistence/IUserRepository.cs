using CrossPlatformChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Contracts.Persistence {
    public interface IUserRepository : IAsyncRepository<User> {
        Task<User> GetUserByEmail(string email);
        Task<User> RegisterUser(string email, string password, string? name = null, string? image = null);
        Task<User> LoginAsync(string email, string password);
        Task ForgotPassword(string email);
        Task<User> AddFriend(Guid id, Guid friend);
        Task RemoveFriend(Guid id, Guid friend);
        Task<User> AddChat(Guid id, Guid chat);
        Task RemoveChat(Guid id, Guid chat);
        Task LogOut(Guid id);
        Task<List<User>> GetAllFriendsDetails(List<Guid> friends);
    }
}
