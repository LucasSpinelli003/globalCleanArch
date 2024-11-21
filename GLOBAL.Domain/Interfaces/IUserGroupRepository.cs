using GLOBAL.Domain.Entities;

namespace GLOBAL.Domain.Interfaces
{
    public interface IUserGroupRepository
    {
        UserGroupEntity? ObterPorId(int id);
        IEnumerable<UserGroupEntity>? ObterTodos();
        UserGroupEntity? Adicionar(UserGroupEntity cliente);
        UserGroupEntity? Editar(UserGroupEntity cliente);
        UserGroupEntity? Remover(int id);
    }
}
