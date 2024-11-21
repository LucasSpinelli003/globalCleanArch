using GLOBAL.Data.AppData;
using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;

namespace GLOBAL.Data.Repositories
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly ApplicationContext _context;

        public UserGroupRepository(ApplicationContext context)
        {
            _context = context;
        }

        public UserGroupEntity? Adicionar(UserGroupEntity userGroup)
        {
            _context.UserGroup.Add(userGroup);
            _context.SaveChanges();

            return userGroup;
        }

        public UserGroupEntity? Editar(UserGroupEntity userGroup)
        {
               var entity = _context.UserGroup.Find(userGroup.Id);
            
            if (entity is not null)
            {
                entity.IsActive = userGroup.IsActive;
                entity.Name = userGroup.Name;
                
                _context.UserGroup.Update(entity);
                _context.SaveChanges();
                return userGroup;
            }
            return null;  

        }

        public UserGroupEntity? ObterPorId(int id)
        {
            var entity = _context.UserGroup.Find(id);
            
            if (entity is not null)
            {
                return entity;
            }
            return null;   

        }

        public IEnumerable<UserGroupEntity> ObterTodos()
        {
             var entity = _context.UserGroup.ToList();

            return entity;

        }

        public UserGroupEntity? Remover(int id)
        {
            var entity = _context.UserGroup.Find(id);
            
            if (entity is not null)
            {
                _context.UserGroup.Remove(entity);
                _context.SaveChanges();

                return entity;
            }
            return null;  

        }
    }
}
