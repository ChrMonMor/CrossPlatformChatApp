using CrossPlatformChatApp.App.Views;

namespace CrossPlatformChatApp.App {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
        }
    }
}
