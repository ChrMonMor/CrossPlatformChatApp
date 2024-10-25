namespace CrossPlatformChatApp.Application.Features.Messages.Commands.SendMessageCommand {
    public class SendMessageCommandVm {
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public bool IsImage { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}