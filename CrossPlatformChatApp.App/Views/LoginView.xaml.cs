using CrossPlatformChatApp.App.ViewModels;

namespace CrossPlatformChatApp.App.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel vm) {
        InitializeComponent();
        BindingContext = vm;
	}
}