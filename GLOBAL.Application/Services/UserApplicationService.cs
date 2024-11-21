using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;
using GLOBAL.Domain.Interfaces.Dtos;

namespace GLOBAL.Application.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserRepository _repository;

        public UserApplicationService(IUserRepository repository)
        {
            _repository = repository;
        }

        public UserEntity AdicionarUser(IUserDto entity)
        {
            return _repository.Adicionar(new UserEntity
            {
                Name = entity.Name,
                Cpf = entity.Cpf,
                Email = entity.Email,
                IsActive = entity.IsActive,
                Password = entity.Password,
                DeviceId = entity.DeviceId,
                UserGroupId = entity.UserGroupId
            });

        }

        public UserEntity EditarUser(int id, IUserDto entity)
        {
              return _repository.Editar(new UserEntity
            {
                Id = id,
                Name = entity.Name,
                Cpf = entity.Cpf,
                DeviceId = entity.DeviceId,
                Email = entity.Email,
                IsActive = entity.IsActive,
                Password = entity.Password,
                UserGroupId = entity.UserGroupId,
            });

        }

        public UserEntity ObterUserPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<UserEntity>? ObterTodosUsers()
        {
            return _repository.ObterTodos();
        }

        public UserEntity RemoverUser(int id)
        {
            return _repository.Remover(id);
        }
    }
}
