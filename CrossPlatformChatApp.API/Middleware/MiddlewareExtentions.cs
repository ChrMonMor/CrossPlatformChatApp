namespace CrossPlatformChatApp.API.Middleware {
    public static class MiddlewareExtentions {
        public static IApplicationBuilder UseCustomMiddlewareExceptionHandler(this IApplicationBuilder builder) { 
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
