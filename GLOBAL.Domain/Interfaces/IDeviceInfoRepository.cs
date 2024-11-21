using GLOBAL.Domain.Entities;

namespace GLOBAL.Domain.Interfaces
{
    public interface IDeviceInfoRepository
    {
        DeviceInfoEntity? ObterPorId(int id);
        IEnumerable<DeviceInfoEntity>? ObterTodos();
        DeviceInfoEntity? Adicionar(DeviceInfoEntity cliente);
        DeviceInfoEntity? Editar(DeviceInfoEntity cliente);
        DeviceInfoEntity? Remover(int id);
    }
}
