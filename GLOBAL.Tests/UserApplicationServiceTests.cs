using GLOBAL.Application.Services;
using GLOBAL.Domain.Interfaces;
using Moq;

namespace GLOBAL.Tests
{
    public class UserApplicationServiceTests
    {
        private readonly Mock<IUserRepository> _repositoryMock;
        private readonly UserApplicationService _userService;

        public UserApplicationServiceTests()
        {
            _repositoryMock = new Mock<IUserRepository>();
        }

        

    }
}
