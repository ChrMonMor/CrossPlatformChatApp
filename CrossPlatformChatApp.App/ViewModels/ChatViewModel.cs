using CommunityToolkit.Mvvm.ComponentModel;
using CrossPlatformChatApp.App.Data.Interfaces;
using CrossPlatformChatApp.App.Models;

namespace CrossPlatformChatApp.App.ViewModels
{
    [QueryProperty(nameof(ChatId), "ChatId")]
    public partial class ChatViewModel : ObservableObject {

        [ObservableProperty]
        Guid _chatId;
        [ObservableProperty]
        ChatDto _chatDetails;
        [ObservableProperty]
        bool _navigation;

        private readonly IChatService _chatService;
        private readonly Task _initTask;

        public ChatViewModel(IChatService chatService) {
            Navigation = true;
            _chatService = chatService;
            _chatDetails = new ChatDto();
            _initTask = ActiveInitAsync();
            Navigation = false;
        }
        private async Task InitAsync() { 
            var chatDetails = await _chatService.GetChatDto(ChatId);
            ChatDetails = chatDetails;
        }

        public async Task ActiveInitAsync() {
            await InitAsync();
        }
    }
}