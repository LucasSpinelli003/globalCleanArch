using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;
using GLOBAL.Domain.Interfaces.Dtos;

namespace GLOBAL.Application.Services
{
    public class UserGroupApplicationService : IUserGroupApplicationService
    {
        private readonly IUserGroupRepository _repository;

        public UserGroupApplicationService(IUserGroupRepository repository)
        {
            _repository = repository;
        }

        public UserGroupEntity AdicionarUserGroup(IUserGroupDto entity)
        {
            return _repository.Adicionar(new UserGroupEntity
            {
                IsActive = entity.IsActive,
                Name = entity.Name,
            });

        }

        public UserGroupEntity EditarUserGroup(int id, IUserGroupDto entity)
        {
              return _repository.Editar(new UserGroupEntity
            {
                Id = id,
                IsActive = entity.IsActive,
                Name = entity.Name,
            });

        }

        public UserGroupEntity ObterUserGroupPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<UserGroupEntity>? ObterTodosUserGroups()
        {
            return _repository.ObterTodos();
        }

        public UserGroupEntity RemoverUserGroup(int id)
        {
            return _repository.Remover(id);
        }
    }
}
