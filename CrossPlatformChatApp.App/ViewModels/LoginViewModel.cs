using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrossPlatformChatApp.App.Data.Interfaces;
using CrossPlatformChatApp.App.Models;
using CrossPlatformChatApp.App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.App.ViewModels {
    public partial class LoginViewModel : ObservableObject {


        [ObservableProperty]
        string _email;
        [ObservableProperty]
        string _password;
        [ObservableProperty]
        bool _navigating;

        private readonly IAuthService _authService;

        public LoginViewModel(IAuthService authService) {
            _authService = authService;
        }
        [RelayCommand]
        public async Task Login() {
            Navigating = true;
            UserDto user = await _authService.Login(Email, Password);

            if (user == null) {
                CancellationTokenSource cancellationTokenSource = new();
                var toast = Toast.Make("Wrong Email or Password", ToastDuration.Short, 14);
                await toast.Show(cancellationTokenSource.Token);

                Navigating = false;
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(UserView)}?Username={user.Name}");
                
            Navigating = false;
        }
    }
}
