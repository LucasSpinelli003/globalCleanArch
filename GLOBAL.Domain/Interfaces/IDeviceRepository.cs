using GLOBAL.Domain.Entities;

namespace GLOBAL.Domain.Interfaces
{
    public interface IDeviceRepository
    {
        DeviceEntity? ObterPorId(int id);
        IEnumerable<DeviceEntity>? ObterTodos();
        DeviceEntity? Adicionar(DeviceEntity cliente);
        DeviceEntity? Editar(DeviceEntity cliente);
        DeviceEntity? Remover(int id);
    }
}
