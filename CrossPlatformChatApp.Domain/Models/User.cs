using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Image {  get; set; } = string.Empty;
        public bool IsConfirmed { get; set; } = false;
        public List<Guid> Friends { get; set; } = [];
        public List<Guid> Chats { get; set; } = [];
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Edited { get; set; }
    }
}
