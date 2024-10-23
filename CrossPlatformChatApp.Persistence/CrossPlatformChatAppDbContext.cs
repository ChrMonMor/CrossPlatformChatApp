using CrossPlatformChatApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace CrossPlatformChatApp.Persistence {
    public class CrossPlatformChatAppDbContext(DbContextOptions options) : DbContext(options) {
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrossPlatformChatAppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToCollection("Users");
            modelBuilder.Entity<Chat>().ToCollection("Chats");
        }
    }
}
