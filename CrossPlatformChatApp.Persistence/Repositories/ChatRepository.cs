﻿using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CrossPlatformChatApp.Persistence.Repositories {
    public class ChatRepository(CrossPlatformChatAppDbContext dbContext) : BaseRepository<Chat>(dbContext), IChatRepository {
        public Task<Chat> GetChat(Guid chatId) {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetChatMembersDetails(List<Guid> members) {
            var list = await _dbContext.Set<User>().ToListAsync();
            return list.Where(x => members.Any(c => c == x.Id)).ToList();
        }

        public async Task<List<Chat>> GetUsersChatsDetails(List<Guid> chats) {
            var list = await _dbContext.Set<Chat>().ToListAsync();
            return list.Where(x => chats.Any(c => c == x.Id)).ToList();
        }

    }
}
