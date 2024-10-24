using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CrossPlatformChatApp.App.ViewModels
{
    public partial class ForgotPasswordViewModel : ObservableObject {
        [ObservableProperty]
        string _newPassword;
        [ObservableProperty]
        string _repeatPassword;
        [ObservableProperty]
        bool _isRunning;
        public ForgotPasswordViewModel() { }

        [RelayCommand]
        public async Task ResetPassword() {

        }
    }
}