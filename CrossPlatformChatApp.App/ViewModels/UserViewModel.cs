using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrossPlatformChatApp.App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.App.ViewModels {
    [QueryProperty(nameof(UserDto), "User")]
    public partial class UserViewModel : ObservableObject {
        [ObservableProperty]
        string _user;
        [ObservableProperty]
        UserDto _userDetails;
        [ObservableProperty]
        string _imageUrl;
        [ObservableProperty]
        ObservableCollection<ChatDto> _chats;
        [ObservableProperty]
        ObservableCollection<FriendDto> _friends;
        [ObservableProperty]
        string _password;

        private readonly Task initTask;

        public UserViewModel() {
            _friends = [];
            _chats = [];
            initTask = ActiveInitAsync();
        }
        private async Task InitAsync() {
            UserDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<UserDto>(User);
            Chats = UserDetails.Chats.ToObservableCollection();
            Friends = UserDetails.Friends.ToObservableCollection();
        }

        public async Task ActiveInitAsync() {
            await InitAsync();
        }

        [RelayCommand]
        public async Task NewChat() {

        }
        [RelayCommand]
        public async Task AddFriend() {

        }
    }
}
