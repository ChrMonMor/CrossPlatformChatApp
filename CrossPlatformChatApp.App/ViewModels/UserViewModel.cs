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

        public UserViewModel() {
            _initTask = ActiveInitAsync();
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
            await Shell.Current.GoToAsync($"{nameof(ChatPage)}", new Dictionary<string, object> { { "ChatId", ChatId } });
            Navigation = false;
        }
    }
}
