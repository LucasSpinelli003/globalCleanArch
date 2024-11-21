using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;
using GLOBAL.Domain.Interfaces.Dtos;

namespace GLOBAL.Application.Services
{
    public class DeviceApplicationService : IDeviceApplicationService
    {
        private readonly IDeviceRepository _repository;

        public DeviceApplicationService(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public DeviceEntity AdicionarDevice(IDeviceDto entity)
        {
            return _repository.Adicionar(new DeviceEntity
            {
                DeviceInfoId = entity.DeviceInfoId,
                Name = entity.Name,
            });

        }

        public DeviceEntity EditarDevice(int id, IDeviceDto entity)
        {
              return _repository.Editar(new DeviceEntity
            {
                Id = id,
                DeviceInfoId = entity.DeviceInfoId,
                Name = entity.Name,
            });

        }

        public DeviceEntity ObterDevicePorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<DeviceEntity>? ObterTodosDevices()
        {
            return _repository.ObterTodos();
        }

        public DeviceEntity RemoverDevice(int id)
        {
            return _repository.Remover(id);
        }
    }
}
