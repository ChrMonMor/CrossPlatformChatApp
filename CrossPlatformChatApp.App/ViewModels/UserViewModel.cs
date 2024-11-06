using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrossPlatformChatApp.App.Data.Interfaces;
using CrossPlatformChatApp.App.Models;
using CrossPlatformChatApp.App.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.App.ViewModels {
    [QueryProperty(nameof(User), "User")]
    public partial class UserViewModel : ObservableObject {
        [ObservableProperty]
        UserDto _user;
        [ObservableProperty]
        string _imageUrl;
        [ObservableProperty]
        string _password;
        [ObservableProperty]
        bool _navigation;

        private readonly Task _initTask;
        private readonly IChatService _chatService;

        public UserViewModel(IChatService chatService) {
            _initTask = ActiveInitAsync();
            _chatService = chatService;
        }
        private async Task InitAsync() {
        }

        public async Task ActiveInitAsync() {
            await InitAsync();
        }

        [RelayCommand]
        public async Task NewChat() {
            Navigation = true;

            Navigation = false;
        }
        [RelayCommand]
        public async Task AddFriend() {
            Navigation = true;

            Navigation = false;
        }
        [RelayCommand]
        public async Task OpenChat(Guid ChatId) {
            Navigation = true;

            ChatDto chat = await _chatService.GetChatDto(ChatId);

            if (chat == null) {
                CancellationTokenSource cancellationTokenSource = new();
                var toast = Toast.Make("Something went wrong", ToastDuration.Short, 14);
                await toast.Show(cancellationTokenSource.Token);

                Navigation = false;
                return;
            }

            UserChatDto userChat = new() { User = User, Chat = chat };

            await Shell.Current.GoToAsync($"{nameof(ChatPage)}", new Dictionary<string, object> { { "UserChat", userChat } });
            Navigation = false;
        }
    }
}
