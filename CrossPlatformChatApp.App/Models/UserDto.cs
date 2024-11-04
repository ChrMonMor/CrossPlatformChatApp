using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.App.Models {
    public class UserDto {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public List<FriendDto> Friends { get; set; }
        public List<ChatDto> Chats { get; set; }
    }
}
