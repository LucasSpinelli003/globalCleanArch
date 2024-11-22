using GLOBAL.Data.AppData;
using GLOBAL.Data.Repositories;
using GLOBAL.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GLOBAL.Tests
{
    public class DeviceRepositoryTests
    {
        private readonly DbContextOptions<ApplicationContext> _options;
        private readonly ApplicationContext _context;
        private readonly DeviceRepository _deviceRepository;
        public DeviceRepositoryTests()
        {
        _options = new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "TestDatabase")
                        .Options;

                    _context = new ApplicationContext(_options);
                    _deviceRepository = new DeviceRepository(_context);
        }

        [Fact]
        public void ObterTodos_DeveRetornarListaDeDevice_QuandoExistiremDevices()
        {
            _context.Device.RemoveRange(_context.Device);
            _context.SaveChanges();
            var devices = new List<DeviceEntity>
            {
                new DeviceEntity { Name = "Device 1", DeviceInfoId = 1 },
                new DeviceEntity { Name = "Device 2", DeviceInfoId = 2 }
            };
            _context.Device.AddRange(devices);
            _context.SaveChanges();

            var resultado = _deviceRepository.ObterTodos();
            Assert.Equal(devices.Count, resultado.Count());
            Assert.Equal(devices[0].Name, resultado.First().Name);
            Assert.Equal(devices[1].Name, resultado.Last().Name);
        }

        [Fact]
        public void ObterPorId_DeveRetornarDeviceEntity_QuandoDeviceExiste()
        {
            var device = new DeviceEntity { Name = "Device 1", DeviceInfoId = 1 };
            _context.Device.Add(device);
            _context.SaveChanges();

            var resultado = _deviceRepository.ObterPorId(device.Id);

            Assert.NotNull(resultado);
            Assert.Equal(device.Id, resultado.Id);
            Assert.Equal(device.Name, resultado.Name);
        }

        [Fact]
        public void Remover_DeveRemoverDeviceERetornarDeviceEntity_QuandoDeviceExiste()
        {
            var device = new DeviceEntity { Name = "Device 1", DeviceInfoId = 1 };
            _context.Device.Add(device);
            _context.SaveChanges();

            var resultado = _deviceRepository.Remover(device.Id);

            var deviceNoDb = _context.Device.FirstOrDefault(c => c.Id == device.Id);

            Assert.Null(deviceNoDb);
            Assert.Equal(device, resultado);
        }

        [Fact]
        public void Adicionar_DeveAdicionarDeviceERetornarDeviceEntity()
        {
            var device = new DeviceEntity { Name = "Device 1",  DeviceInfoId = 1 };

            var resultado = _deviceRepository.Adicionar(device);

            var deviceNoDb = _context.Device.FirstOrDefault(c => c.Id == resultado.Id);
            Assert.NotNull(deviceNoDb);
            Assert.Equal(device.Name, deviceNoDb.Name);
            Assert.Equal(device.DeviceInfoId, deviceNoDb.DeviceInfoId);
        }

        [Fact]
        public void Editar_DeveAtualizarBarcoERetornarBarcoEntity_QuandoBarcoExiste()
        {
            var device = new DeviceEntity { Name = "Device 1", DeviceInfoId = 1 };
            _context.Device.Add(device);
            _context.SaveChanges();

            device.Name = "Device 1";
            device.DeviceInfoId = 1;

            var resultado = _deviceRepository.Editar(device);

            var deviceNoDb = _context.Device.FirstOrDefault(c => c.Id == device.Id);
            Assert.NotNull(deviceNoDb);
            Assert.Equal("Device 1", deviceNoDb.Name);
            Assert.Equal(1, deviceNoDb.DeviceInfoId);
        }

    }
}
