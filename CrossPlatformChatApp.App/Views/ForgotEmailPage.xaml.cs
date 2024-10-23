using CrossPlatformChatApp.App.ViewModels;

namespace CrossPlatformChatApp.App.Views;

public partial class ForgotEmailPage : ContentPage
{
	public ForgotEmailPage(ForgotEmailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}