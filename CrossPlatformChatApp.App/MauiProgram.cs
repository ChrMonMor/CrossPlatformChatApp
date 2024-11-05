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
            builder.Services.AddSingleton<IChatService, ChatService>();

            builder.Services.AddSingleton<LoginView>();
            builder.Services.AddSingleton<LoginViewModel>();

            builder.Services.AddTransient<UserPage>();
            builder.Services.AddTransient<UserViewModel>();

            builder.Services.AddTransient<SignUpPage>();
            builder.Services.AddTransient<SignUpViewModel>();

            builder.Services.AddTransient<ForgotEmailPage>();
            builder.Services.AddTransient<ForgotEmailViewModel>();

            builder.Services.AddTransient<ForgotPasswordPage>();
            builder.Services.AddTransient<ForgotPasswordViewModel>();

            builder.Services.AddTransient<ChatPage>();
            builder.Services.AddTransient<ChatViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
