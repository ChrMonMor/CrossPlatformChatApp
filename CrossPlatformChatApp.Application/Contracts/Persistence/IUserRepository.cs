﻿using CrossPlatformChatApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Contracts.Persistence {
    public interface IUserRepository : IAsyncRepository<User> {
        Task<User?> LoginAsync(string email, string password);
        Task<User?> GetUserByEmail(string email);
    }
}
