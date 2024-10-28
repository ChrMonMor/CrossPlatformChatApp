using CrossPlatformChatApp.Persistence;
using Moq;
//using Shouldly;
using CrossPlatformChatApp.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CrossPlatformChatApp.Test.Infrastructure.Persistence.IntegrationTests {
    public class CrossPlatformChatAppDbContextTests {
        private readonly CrossPlatformChatAppDbContext _crossPlatformChatAppDbContext;
        private readonly Mock<ILoggedInUserService> _loggerInUserServiceMock;
        private readonly string _loggedInUserId;

        public CrossPlatformChatAppDbContextTests() {
            var dbContextOptions = new DbContextOptionsBuilder<CrossPlatformChatAppDbContext>().Options;
            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggerInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggerInUserServiceMock.Setup(moq => moq.UserId).Returns(_loggedInUserId);
            _crossPlatformChatAppDbContext = new CrossPlatformChatAppDbContext(dbContextOptions, _loggerInUserServiceMock.Object);
        }/*
        [Fact]
        public async void Save_SetCreatedByProperty() {
            var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test Event" };
            _crossPlatformChatAppDbContext.Events.Add(ev);
            await _crossPlatformChatAppDbContext.SaveChanges();

            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }*/
    }
}
