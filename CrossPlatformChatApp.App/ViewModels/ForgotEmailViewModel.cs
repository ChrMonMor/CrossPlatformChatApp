using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CrossPlatformChatApp.App.ViewModels
{
    public partial class ForgotEmailViewModel : ObservableObject {
        [ObservableProperty]
        string _email;
        [ObservableProperty]
        bool _isRunning;
        ForgotEmailViewModel() { }

        [RelayCommand]
        public async Task SendEmail() {

        }
    }
}