using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Persistence.Repositories {
    public class MessageRepository(CrossPlatformChatAppDbContext dbContext) : BaseRepository<Message>(dbContext), IMessageRepository {
    }
}
