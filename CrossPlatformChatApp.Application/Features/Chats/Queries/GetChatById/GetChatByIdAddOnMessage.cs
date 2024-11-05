namespace CrossPlatformChatApp.Application.Features.Chats.Queries.GetChatById {
    public class GetChatByIdAddOnMessage {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public string Text { get; set; }
        public bool IsImage { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
