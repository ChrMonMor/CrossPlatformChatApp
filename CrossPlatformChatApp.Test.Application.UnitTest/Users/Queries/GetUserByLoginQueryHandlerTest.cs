using AutoMapper;
using CrossPlatformChatApp.Application.Contracts.Persistence;
using CrossPlatformChatApp.Application.Features.Users.Queries.GetUserByLogin;
using CrossPlatformChatApp.Application.Profiles;
using CrossPlatformChatApp.Test.Application.UnitTest.Mocks;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Test.Application.UnitTest.Users.Queries {
    public class GetUserByLoginQueryHandlerTest {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly ILogger<GetUserByLoginQueryHandler> _logger;

        public GetUserByLoginQueryHandlerTest() {
            _mockUserRepository = RepositoryMocks.GetUserRepository();
            var configurationProvider = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task GetUserByLoginTest() {
            var handler = new GetUserByLoginQueryHandler(_mockUserRepository.Object, _mapper, _logger);

            var result = await handler.Handle(new GetUserByLoginQuery() { Email = "str@ing.dk", Password = "string" }, CancellationToken.None);

            result.ShouldBeOfType<GetUserByLoginResponse>();
            result.Success.ShouldBeTrue();
            result.ValidationErrors.Count.ShouldBe(0);
            result.Data.ShouldBeOfType<UserByLoginVm>();
            result.Data.Name.ShouldBe("str@ing.dk");
            result.Data.Email.ShouldBe("str@ing.dk");

        }
    }
}
