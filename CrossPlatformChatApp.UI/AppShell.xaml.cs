using CrossPlatformChatApp.UI.Pages;

namespace CrossPlatformChatApp.UI {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }
    }
}
