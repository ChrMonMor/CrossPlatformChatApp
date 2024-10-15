using CrossPlatformChatApp.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.App.Data.Interfaces {
    public interface IAuthService {
        Task<UserDto> Login(string email, string password);
    }
}
