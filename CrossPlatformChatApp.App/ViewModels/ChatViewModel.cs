using CommunityToolkit.Mvvm.ComponentModel;
using CrossPlatformChatApp.App.Data.Interfaces;
using CrossPlatformChatApp.App.Models;

namespace CrossPlatformChatApp.App.ViewModels
{
    [QueryProperty(nameof(Chat), "Chat")]
    public partial class ChatViewModel : ObservableObject {

        [ObservableProperty]
        ChatDto _chat;
        [ObservableProperty]
        bool _navigation;

        private readonly IChatService _chatService;
        private readonly Task _initTask;

        public ChatViewModel(IChatService chatService) {
            Navigation = true;
            _chatService = chatService;
            _initTask = ActiveInitAsync();
            Navigation = false;
        }
        private async Task InitAsync() { 

        }

        public async Task ActiveInitAsync() {
            await InitAsync();
        }
    }
}