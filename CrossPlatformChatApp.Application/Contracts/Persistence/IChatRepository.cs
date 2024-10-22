using CrossPlatformChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Contracts.Persistence {
    public interface IChatRepository : IAsyncRepository<Chat> {
        Task<List<Chat>> GetUsersChatsDetails(List<Guid> chats);
        Task<List<User>> GetChatMembersDetails(List<Guid> members);
        Task<Chat> GetChat(Guid chatId);

    }
}
