using GLOBAL.Application.Services;
using GLOBAL.Domain.Interfaces;
using Moq;

namespace GLOBAL.Tests
{
    public class AddressApplicationServiceTests
    {
        private readonly Mock<IAddressRepository> _repositoryMock;
        private readonly AddressApplicationService _addressService;

        public AddressApplicationServiceTests()
        {
            _repositoryMock = new Mock<IAddressRepository>();
        }

        

    }
}
