using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.App.Models {
    public class MessageDto {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
