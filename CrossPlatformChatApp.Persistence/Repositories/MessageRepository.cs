using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Persistence.Repositories {
    public class MessageRepository(CrossPlatformChatAppDbContext dbContext) : BaseRepository<Message>(dbContext), IMessageRepository {
        public Task<List<Message>> AddMessage(Guid chat, Message message) {
            throw new NotImplementedException();
        }

        public Task<List<Message>> GetMessagesAsync(Guid chat, int limit = 25) {
            throw new NotImplementedException();
        }

        public Task<List<Message>> RemoveMessage(Guid chat, Guid message) {
            throw new NotImplementedException();
        }
    }
}
