namespace CrossPlatformChatApp.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Edited { get; set; }
    }
}