namespace CrossPlatformChatApp.Application.Features.Users.Queries.GetUserByLogin {
    public class UserByLoginBaseVm {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public List<Guid> Friends { get; set; }
        public List<Guid> Chats { get; set; }
    }
}
