using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CrossPlatformChatApp.App.Data.Interfaces;
using CrossPlatformChatApp.App.Models;
using CrossPlatformChatApp.App.Views;

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
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(user);

            await Shell.Current.GoToAsync($"{nameof(UserPage)}?User={json}");
                
            Navigating = false;
        }
        [RelayCommand]
        public async Task SignUp() {
            Navigating = true;
            await Shell.Current.GoToAsync($"{nameof(SignUpPage)}?Email={Email}");
            Navigating = false;
        }
        [RelayCommand]
        public async Task ForgotPassword() {
            Navigating = true;
            await Shell.Current.GoToAsync($"{nameof(ForgotEmailPage)}");
            Navigating = false;
        }
    }
}
