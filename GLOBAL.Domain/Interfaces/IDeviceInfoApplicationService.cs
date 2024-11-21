using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces.Dtos;

namespace GLOBAL.Domain.Interfaces
{
    public interface IDeviceInfoApplicationService
    {
        IEnumerable<DeviceInfoEntity> ObterTodosDeviceInfos();
        DeviceInfoEntity ObterDeviceInfoPorId(int id);
        DeviceInfoEntity AdicionarDeviceInfo(IDeviceInfoDto entity);
        DeviceInfoEntity EditarDeviceInfo(int id, IDeviceInfoDto entity);
        DeviceInfoEntity RemoverDeviceInfo(int id);

    }
}
