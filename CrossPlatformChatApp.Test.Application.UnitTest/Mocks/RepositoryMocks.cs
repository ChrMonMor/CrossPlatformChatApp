using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Domain.Models;
using CrossPlatformChatApp.Persistence.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Test.Application.UnitTest.Mocks {
    public class RepositoryMocks {
        public static Mock<IUserRepository> GetUserRepository() {
            var user = new User() {
                Id = Guid.Parse("43b3d015-2361-4889-abfe-0d19375458c5"),
                Chats = [],
                Created = DateTime.UtcNow,
                Edited = DateTime.MinValue,
                Email = "str@ing.dk",
                Friends = [],
                Image = "",
                Name = "str@ing.dk",
                Password = "string",
                IsConfirmed = true
            };
            List<User> users = new List<User>() { };
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.LoginAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(user);

            return mockUserRepository;
        }
    }
}
