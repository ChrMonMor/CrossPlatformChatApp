using CrossPlatformChatApp.App.ViewModels;

namespace CrossPlatformChatApp.App.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(SignUpViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}