using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Users.Queries.GetUserByLogin {
    public class UserByLoginVm {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public List<UserByLoginAddOnFriendVm> Friends { get; set; } = [];
        public List<UserByLoginAddOnChatVm> Chats { get; set; } = [];
    }
}
