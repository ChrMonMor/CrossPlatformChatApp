using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Features.Users.Queries.GetUserById {
    public class UserByIdVm {

        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public List<Guid>? Friends { get; set; }
        public List<Guid>? Chats { get; set; }
    }
}
