using CrossPlatformChatApp.UI.ViewModels;

namespace CrossPlatformChatApp.UI.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}