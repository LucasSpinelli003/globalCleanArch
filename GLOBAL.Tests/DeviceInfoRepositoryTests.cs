using GLOBAL.Data.AppData;
using GLOBAL.Data.Repositories;
using GLOBAL.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GLOBAL.Tests
{
    public class DeviceInfoRepositoryTests
    {
        private readonly DbContextOptions<ApplicationContext> _options;
        private readonly ApplicationContext _context;
        private readonly DeviceInfoRepository _deviceInfoRepository;
        public DeviceInfoRepositoryTests()
        {
        _options = new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "TestDatabase")
                        .Options;

                    _context = new ApplicationContext(_options);
                    _deviceInfoRepository = new DeviceInfoRepository(_context);
        }

        [Fact]
        public void ObterTodos_DeveRetornarListaDeDeviceInfo_QuandoExistiremDevicesInfo()
        {
            _context.DeviceInfo.RemoveRange(_context.DeviceInfo);
            _context.SaveChanges();
            var devicesInfo = new List<DeviceInfoEntity>
            {
                new DeviceInfoEntity { EnergyLevel = 20, voltage = 10 },
                new DeviceInfoEntity { EnergyLevel = 20, voltage = 10 }
            };
            _context.DeviceInfo.AddRange(devicesInfo);
            _context.SaveChanges();

            var resultado = _deviceInfoRepository.ObterTodos();
            Assert.Equal(devicesInfo.Count, resultado.Count());
            Assert.Equal(devicesInfo[0].EnergyLevel, resultado.First().EnergyLevel);
            Assert.Equal(devicesInfo[1].EnergyLevel, resultado.Last().EnergyLevel);
        }

        [Fact]
        public void ObterPorId_DeveRetornarDeviceInfoEntity_QuandoDeviceInfoExiste()
        {
            var deviceInfo = new DeviceInfoEntity { EnergyLevel = 20, voltage = 15 };
            _context.DeviceInfo.Add(deviceInfo);
            _context.SaveChanges();

            var resultado = _deviceInfoRepository.ObterPorId(deviceInfo.Id);

            Assert.NotNull(resultado);
            Assert.Equal(deviceInfo.EnergyLevel, resultado.EnergyLevel);
            Assert.Equal(deviceInfo.voltage, resultado.voltage);
        }

        [Fact]
        public void Remover_DeveRemoverDeviceInfoERetornarDeviceEntity_QuandoDeviceInfoExiste()
        {
            var deviceInfo = new DeviceInfoEntity { EnergyLevel = 15, voltage = 22 };
            _context.DeviceInfo.Add(deviceInfo);
            _context.SaveChanges();

            var resultado = _deviceInfoRepository.Remover(deviceInfo.Id);

            var deviceInfoNoDb = _context.DeviceInfo.FirstOrDefault(c => c.Id == deviceInfo.Id);

            Assert.Null(deviceInfoNoDb);
            Assert.Equal(deviceInfo, resultado);
        }

        [Fact]
        public void Adicionar_DeveAdicionarDeviceInfoERetornarDeviceInfoEntity()
        {
            var deviceInfo = new DeviceInfoEntity { EnergyLevel = 12, voltage = 22 };

            var resultado = _deviceInfoRepository.Adicionar(deviceInfo);

            var deviceInfoNoDb = _context.DeviceInfo.FirstOrDefault(c => c.Id == resultado.Id);
            Assert.NotNull(deviceInfoNoDb);
            Assert.Equal(deviceInfo.EnergyLevel, deviceInfoNoDb.EnergyLevel);
            Assert.Equal(deviceInfo.voltage, deviceInfoNoDb.voltage);
        }

        [Fact]
        public void Editar_DeveAtualizarDeviceInfoERetornarDeviceInfoEntity_QuandoDeviceInfoExiste()
        {
            var deviceInfo = new DeviceInfoEntity { EnergyLevel = 9, voltage = 14 };
            _context.DeviceInfo.Add(deviceInfo);
            _context.SaveChanges();

            deviceInfo.EnergyLevel = 20;
            deviceInfo.voltage= 14;

            var resultado = _deviceInfoRepository.Editar(deviceInfo);

            var deviceInfoNoDb = _context.DeviceInfo.FirstOrDefault(c => c.Id == deviceInfo.Id);
            Assert.NotNull(deviceInfoNoDb);
            Assert.Equal(20, deviceInfoNoDb.EnergyLevel);
            Assert.Equal(14, deviceInfoNoDb.voltage);
        }

    }
}
