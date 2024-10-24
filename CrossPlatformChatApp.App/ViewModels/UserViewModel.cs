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
    public partial class UserViewModel : ObservableObject {

        [ObservableProperty]
        string _imageUrl;
        [ObservableProperty]
        ObservableCollection<ChatDto> _chats;
        [ObservableProperty]
        ObservableCollection<FriendDto> _friends;
        [ObservableProperty]
        UserDto _userDetails;
        [ObservableProperty]
        string _password;

        public UserViewModel() { 

        }

        [RelayCommand]
        public async Task NewChat() {

        }
        [RelayCommand]
        public async Task AddFriend() {

        }
    }
}
