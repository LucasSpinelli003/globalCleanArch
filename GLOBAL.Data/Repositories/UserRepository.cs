using GLOBAL.Data.AppData;
using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;

namespace GLOBAL.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public UserEntity? Adicionar(UserEntity user)
        {
            _context.User.Add(user);
            _context.SaveChanges();

            return user;
        }

        public UserEntity? Editar(UserEntity user)
        {
               var entity = _context.User.Find(user.Id);
            
            if (entity is not null)
            {
                entity.Name = user.Name;
                entity.Email = user.Email;
                entity.DeviceId = user.DeviceId;
                entity.IsActive = user.IsActive;
                entity.Password = user.Password;
                
                _context.User.Update(entity);
                _context.SaveChanges();
                return user;
            }
            return null;  

        }

        public UserEntity? ObterPorId(int id)
        {
            var entity = _context.User.Find(id);
            
            if (entity is not null)
            {
                return entity;
            }
            return null;   

        }

        public IEnumerable<UserEntity> ObterTodos()
        {
             var entity = _context.User.ToList();

            return entity;

        }

        public UserEntity? Remover(int id)
        {
            var entity = _context.User.Find(id);
            
            if (entity is not null)
            {
                _context.User.Remove(entity);
                _context.SaveChanges();

                return entity;
            }
            return null;  

        }
    }
}
