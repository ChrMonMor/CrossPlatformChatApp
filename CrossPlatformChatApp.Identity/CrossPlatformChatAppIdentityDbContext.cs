using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CrossPlatformChatApp.Identity.Models;

namespace CrossPlatformChatApp.Identity {
    public class CrossPlatformChatAppIdentityDbContext : IdentityDbContext<ApplicationUser> {
        public CrossPlatformChatAppIdentityDbContext() { }
        public CrossPlatformChatAppIdentityDbContext(DbContextOptions<CrossPlatformChatAppIdentityDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging();
    }
}
