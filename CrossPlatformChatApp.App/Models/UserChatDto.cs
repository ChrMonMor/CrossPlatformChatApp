using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.App.Models {
    public class UserChatDto {
        public UserDto User { get; set; }
        public ChatDto Chat { get; set; }
    }
}
