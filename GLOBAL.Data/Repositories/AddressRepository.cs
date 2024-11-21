using GLOBAL.Data.AppData;
using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;

namespace GLOBAL.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationContext _context;

        public AddressRepository(ApplicationContext context)
        {
            _context = context;
        }

        public AddressEntity? Adicionar(AddressEntity Address)
        {
            _context.Address.Add(Address);
            _context.SaveChanges();

            return Address;
        }

        public AddressEntity? Editar(AddressEntity address)
        {
               var entity = _context.Address.Find(address.Id);
            
            if (entity is not null)
            {
                entity.Neighborhood = address.Neighborhood;
                entity.Number = address.Number;
                entity.Street = address.Street;
                
                _context.Address.Update(entity);
                _context.SaveChanges();
                return address;
            }
            return null;  

        }

        public AddressEntity? ObterPorId(int id)
        {
            var entity = _context.Address.Find(id);
            
            if (entity is not null)
            {
                return entity;
            }
            return null;   

        }

        public IEnumerable<AddressEntity> ObterTodos()
        {
             var entity = _context.Address.ToList();

            return entity;

        }

        public AddressEntity? Remover(int id)
        {
            var entity = _context.Address.Find(id);
            
            if (entity is not null)
            {
                _context.Address.Remove(entity);
                _context.SaveChanges();

                return entity;
            }
            return null;  

        }
    }
}
