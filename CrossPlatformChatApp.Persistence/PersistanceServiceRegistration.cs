using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CrossPlatformChatApp.Persistence {
    public static class PersistanceServiceRegistration {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
            var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDbConnection"));
            services.AddDbContext<CrossPlatformChatAppDbContext>(options => {
                options.UseMongoDB(mongoClient, configuration.GetSection("DatabaseName")["MongoDB"]);
            });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            return services;
        }
    }
}
