using GLOBAL.Application.Services;
using GLOBAL.Domain.Interfaces;
using Moq;

namespace GLOBAL.Tests
{
    public class DeviceApplicationServiceTests
    {
        private readonly Mock<IDeviceRepository> _repositoryMock;
        private readonly DeviceApplicationService _deviceService;

        public DeviceApplicationServiceTests()
        {
            _repositoryMock = new Mock<IDeviceRepository>();
        }

        

    }
}
