using CrossPlatformChatApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using CrossPlatformChatApp.Application.Contracts;

namespace CrossPlatformChatApp.Persistence {
    public class CrossPlatformChatAppDbContext : DbContext {
        private readonly ILoggedInUserService _loggedInUserService;
        public CrossPlatformChatAppDbContext (DbContextOptions<CrossPlatformChatAppDbContext> options) : base(options) { }

        public CrossPlatformChatAppDbContext(DbContextOptions<CrossPlatformChatAppDbContext> options, ILoggedInUserService loggedInUserService) : base(options) {
            _loggedInUserService = loggedInUserService;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrossPlatformChatAppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToCollection("Users");
            modelBuilder.Entity<Chat>().ToCollection("Chats");
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) {

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
