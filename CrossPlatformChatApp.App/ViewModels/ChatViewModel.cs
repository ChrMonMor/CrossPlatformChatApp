using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrossPlatformChatApp.App.Data.Interfaces;
using CrossPlatformChatApp.App.Models;
using System.Collections.ObjectModel;

namespace CrossPlatformChatApp.App.ViewModels
{
    [QueryProperty(nameof(UserChat), "UserChat")]
    public partial class ChatViewModel : ObservableObject {

        [ObservableProperty]
        UserChatDto _userChat;
        [ObservableProperty]
        ObservableCollection<MessageDto> _messages;
        [ObservableProperty]
        string _messageText;
        [ObservableProperty]
        bool _navigation;

        private readonly IChatService _chatService;
        private readonly Task _initTask;

        public ChatViewModel(IChatService chatService) {
            Messages = []; 
            Navigation = true;
            _chatService = chatService;
            _initTask = ActiveInitAsync();
            Navigation = false;
        }
        private async Task InitAsync() {
            Messages = UserChat.Chat.Messages.ToObservableCollection();
        }

        public async Task ActiveInitAsync() {
            await InitAsync();
        }

        [RelayCommand]
        public async Task UploadImage() {

        }

        [RelayCommand]
        public async Task SendMessage() {
            Navigation = true;

            if (String.IsNullOrWhiteSpace(MessageText)) {
                CancellationTokenSource cancellationTokenSource = new();
                var toast = Toast.Make("No message detected", ToastDuration.Short, 14);
                await toast.Show(cancellationTokenSource.Token);

                Navigation = false;
                return;
            }

            SendMessageDto message = new SendMessageDto() { 
                Sender = UserChat.User.Id,
                ChatId = UserChat.Chat.Id,
                Message = MessageText,
                IsImage = false,
            };

            ChatDto chat = await _chatService.SendMessage(message);

            if (chat == null) {
                CancellationTokenSource cancellationTokenSource = new();
                var toast = Toast.Make("Something went wrong", ToastDuration.Short, 14);
                await toast.Show(cancellationTokenSource.Token);

                Navigation = false;
                return;
            }
            UserChat.Chat = chat;
            await ActiveInitAsync();
            MessageText = "";
            Navigation = false;
        }
    }
}