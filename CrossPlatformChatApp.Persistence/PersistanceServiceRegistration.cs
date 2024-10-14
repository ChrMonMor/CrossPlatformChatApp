using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Persistence {
    public static class PersistanceServiceRegistration {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
            var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDbConnection"));
            services.AddDbContext<CrossPlatformChatAppDbContext>(options => {
                options.UseMongoDB(mongoClient, configuration.GetSection("DatabaseName")["MongoDB"]);
            });


            return services;
        }
    }
}
