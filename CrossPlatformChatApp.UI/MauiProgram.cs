using CommunityToolkit.Maui;
using CrossPlatformChatApp.UI.Pages;
using CrossPlatformChatApp.UI.ViewModels;
using Microsoft.Extensions.Logging;

namespace CrossPlatformChatApp.UI {
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<LoginView>();
            builder.Services.AddSingleton<LoginViewModel>();

            return builder.Build();
        }
    }
}
