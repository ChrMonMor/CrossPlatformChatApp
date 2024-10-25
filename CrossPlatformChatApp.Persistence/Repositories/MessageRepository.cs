using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Persistence.Repositories {
    public class MessageRepository(CrossPlatformChatAppDbContext dbContext) : BaseRepository<Message>(dbContext), IMessageRepository {
        public async Task AddMessage(Guid chat, Message message) {
            var entity = await _dbContext.Set<Chat>().FirstAsync(x => x.Id == chat);
            entity.Messages.Add(message);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<Message>> GetMessagesAsync(Guid chat, int limit = 25) {
            throw new NotImplementedException();
        }

        public Task<List<Message>> RemoveMessage(Guid chat, Guid message) {
            throw new NotImplementedException();
        }
    }
}
