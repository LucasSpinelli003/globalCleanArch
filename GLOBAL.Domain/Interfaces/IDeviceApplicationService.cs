using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces.Dtos;

namespace GLOBAL.Domain.Interfaces
{
    public interface IDeviceApplicationService
    {
        IEnumerable<DeviceEntity> ObterTodosDevices();
        DeviceEntity ObterDevicePorId(int id);
        DeviceEntity AdicionarDevice(IDeviceDto entity);
        DeviceEntity EditarDevice(int id, IDeviceDto entity);
        DeviceEntity RemoverDevice(int id);

    }
}
