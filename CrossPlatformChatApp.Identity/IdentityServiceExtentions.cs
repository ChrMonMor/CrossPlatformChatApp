using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CrossPlatformChatApp.Identity.Models;
using MongoDB.Driver;

namespace CrossPlatformChatApp.Identity {
    public static class IdentityServiceExtentions {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
            services.AddAuthorizationBuilder();

            services.AddDbContext<CrossPlatformChatAppIdentityDbContext>(options => 
            options.UseMongoDB(new MongoClient(configuration.GetConnectionString("MongoDbConnection")), configuration.GetSection("DatabaseName")["MongoDB"]));

            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<CrossPlatformChatAppIdentityDbContext>()
                .AddApiEndpoints();
        }
    }
}
