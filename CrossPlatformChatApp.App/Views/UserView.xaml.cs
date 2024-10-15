using CrossPlatformChatApp.App.ViewModels;

namespace CrossPlatformChatApp.App.Views;

public partial class UserView : ContentView
{
	public UserView(UserViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}