using GLOBAL.Data.AppData;
using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;

namespace GLOBAL.Data.Repositories
{
    public class DeviceInfoRepository : IDeviceInfoRepository
    {
        private readonly ApplicationContext _context;

        public DeviceInfoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public DeviceInfoEntity? Adicionar(DeviceInfoEntity deviceInfo)
        {
            _context.DeviceInfo.Add(deviceInfo);
            _context.SaveChanges();

            return deviceInfo;
        }

        public DeviceInfoEntity? Editar(DeviceInfoEntity deviceInfo)
        {
               var entity = _context.DeviceInfo.Find(deviceInfo.Id);
            
            if (entity is not null)
            {
                entity.EnergyLevel = deviceInfo.EnergyLevel;
                entity.voltage = deviceInfo.voltage;
                
                _context.DeviceInfo.Update(entity);
                _context.SaveChanges();
                return deviceInfo;
            }
            return null;  

        }

        public DeviceInfoEntity? ObterPorId(int id)
        {
            var entity = _context.DeviceInfo.Find(id);
            
            if (entity is not null)
            {
                return entity;
            }
            return null;   

        }

        public IEnumerable<DeviceInfoEntity> ObterTodos()
        {
             var entity = _context.DeviceInfo.ToList();

            return entity;

        }

        public DeviceInfoEntity? Remover(int id)
        {
            var entity = _context.DeviceInfo.Find(id);
            
            if (entity is not null)
            {
                _context.DeviceInfo.Remove(entity);
                _context.SaveChanges();

                return entity;
            }
            return null;  

        }
    }
}
