using CrossPlatformChatApp.App.ViewModels;

namespace CrossPlatformChatApp.App.Views;

public partial class SignUpView : ContentView
{
	public SignUpView(SignUpViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}