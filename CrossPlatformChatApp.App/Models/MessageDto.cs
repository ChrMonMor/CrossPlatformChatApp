using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.App.Models {
    public class MessageDto {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public string Text { get; set; }
        public bool IsImage { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
