using CrossPlatformChatApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Bson;

namespace CrossPlatformChatApp.Persistence.Configurations {
    public class ChatConfiguration : IEntityTypeConfiguration<Chat> {
        public void Configure(EntityTypeBuilder<Chat> builder) {
            builder.ToBson();
        }
    }
}
