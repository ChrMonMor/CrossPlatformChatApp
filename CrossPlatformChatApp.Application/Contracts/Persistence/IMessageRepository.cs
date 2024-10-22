using CrossPlatformChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Contracts.Persistence {
    public interface IMessageRepository : IAsyncRepository<Message> {
        Task<List<Message>> GetMessagesAsync(Guid chat, int limit = 25);
        Task<List<Message>> AddMessage(Guid chat, Message message);
        Task<List<Message>> RemoveMessage(Guid chat, Guid message);
        Task
    }
}
