using GLOBAL.Data.AppData;
using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;

namespace GLOBAL.Data.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationContext _context;

        public DeviceRepository(ApplicationContext context)
        {
            _context = context;
        }

        public DeviceEntity? Adicionar(DeviceEntity device)
        {
            _context.Device.Add(device);
            _context.SaveChanges();

            return device;
        }

        public DeviceEntity? Editar(DeviceEntity device)
        {
               var entity = _context.Device.Find(device.Id);
            
            if (entity is not null)
            {
                entity.DeviceInfoId = device.DeviceInfoId;
                entity.Name = device.Name;
                
                _context.Device.Update(entity);
                _context.SaveChanges();
                return device;
            }
            return null;  

        }

        public DeviceEntity? ObterPorId(int id)
        {
            var entity = _context.Device.Find(id);
            
            if (entity is not null)
            {
                return entity;
            }
            return null;   

        }

        public IEnumerable<DeviceEntity> ObterTodos()
        {
             var entity = _context.Device.ToList();

            return entity;

        }

        public DeviceEntity? Remover(int id)
        {
            var entity = _context.Device.Find(id);
            
            if (entity is not null)
            {
                _context.Device.Remove(entity);
                _context.SaveChanges();

                return entity;
            }
            return null;  

        }
    }
}
