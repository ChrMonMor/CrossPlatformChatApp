using CrossPlatformChatApp.API;

var builder = WebApplication.CreateBuilder(args);

var app = builder
    .ConfigureServices()
    .ConfigurePipline();


app.Run();
