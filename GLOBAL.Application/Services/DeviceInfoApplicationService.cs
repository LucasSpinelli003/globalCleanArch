using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;
using GLOBAL.Domain.Interfaces.Dtos;

namespace GLOBAL.Application.Services
{
    public class DeviceInfoApplicationService : IDeviceInfoApplicationService
    {
        private readonly IDeviceInfoRepository _repository;

        public DeviceInfoApplicationService(IDeviceInfoRepository repository)
        {
            _repository = repository;
        }

        public DeviceInfoEntity AdicionarDeviceInfo(IDeviceInfoDto entity)
        {
            return _repository.Adicionar(new DeviceInfoEntity
            {
                EnergyLevel = entity.EnergyLevel,
                voltage = entity.voltage,
            });

        }

        public DeviceInfoEntity EditarDeviceInfo(int id, IDeviceInfoDto entity)
        {
              return _repository.Editar(new DeviceInfoEntity
            {
                Id = id,
                EnergyLevel = entity.EnergyLevel,
                voltage = entity.voltage,
            });

        }

        public DeviceInfoEntity ObterDeviceInfoPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<DeviceInfoEntity>? ObterTodosDeviceInfos()
        {
            return _repository.ObterTodos();
        }

        public DeviceInfoEntity RemoverDeviceInfo(int id)
        {
            return _repository.Remover(id);
        }
    }
}
