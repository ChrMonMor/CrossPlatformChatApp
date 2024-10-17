using CrossPlatformChatApp.App.ViewModels;

namespace CrossPlatformChatApp.App.Views;

public partial class UserPage : ContentPage
{
	public UserPage(UserViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}