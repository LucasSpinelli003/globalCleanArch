using GLOBAL.Application.Services;
using GLOBAL.Domain.Interfaces;
using Moq;

namespace GLOBAL.Tests
{
    public class DeviceInfoApplicationServiceTests
    {
        private readonly Mock<IDeviceInfoRepository> _repositoryMock;
        private readonly DeviceInfoApplicationService _deviceInfoService;

        public DeviceInfoApplicationServiceTests()
        {
            _repositoryMock = new Mock<IDeviceInfoRepository>();
        }

        

    }
}
