using CommunityToolkit.Maui;
using CrossPlatformChatApp.App.Data.Interfaces;
using CrossPlatformChatApp.App.Data.Services;
using CrossPlatformChatApp.App.ViewModels;
using CrossPlatformChatApp.App.Views;
using Microsoft.Extensions.Logging;

namespace CrossPlatformChatApp.App {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IAuthService, AuthService>();

            builder.Services.AddSingleton<LoginView>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<UserView>();
            builder.Services.AddSingleton<UserViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
