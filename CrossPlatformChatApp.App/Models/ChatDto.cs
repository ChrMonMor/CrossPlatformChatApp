using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.App.Models {
    public class ChatDto {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<UserDto> Members { get; set; }
        public List<MessageDto> Messages { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
