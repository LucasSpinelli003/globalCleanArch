using GLOBAL.Application.Services;
using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;
using GLOBAL.Domain.Interfaces.Dtos;
using Moq;

namespace GLOBAL.Tests
{
    public class BarcoApplicationServiceTests
    {
        private readonly Mock<IBarcoRepository> _repositoryMock;
        private readonly BarcoApplicationService _BarcoService;

        public BarcoApplicationServiceTests()
        {
            _repositoryMock = new Mock<IBarcoRepository>();
        }

        

    }
}
