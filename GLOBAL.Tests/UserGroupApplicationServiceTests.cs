using GLOBAL.Application.Services;
using GLOBAL.Domain.Interfaces;
using Moq;

namespace GLOBAL.Tests
{
    public class UserGroupApplicationServiceTests
    {
        private readonly Mock<IUserGroupRepository> _repositoryMock;
        private readonly UserGroupApplicationService _BarcoService;

        public UserGroupApplicationServiceTests()
        {
            _repositoryMock = new Mock<IUserGroupRepository>();
        }

        

    }
}
