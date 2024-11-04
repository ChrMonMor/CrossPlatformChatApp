using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.App.Models {
    public class MessageDto {
        public MessageDto(UserDto user, string text, bool isImage, DateTime created, DateTime updated) {
            User = user;
            Text = text;
            IsImage = isImage;
            Created = created;
            Updated = updated;
            PostedTime = created < updated ? created : updated;
        }

        public int Id { get; set; }
        public UserDto User { get; set; }
        public string Text { get; set; }
        public bool IsImage { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime PostedTime { get; set; }

    }
}
