using GLOBAL.Domain.Entities;

namespace GLOBAL.Domain.Interfaces
{
    public interface IUserRepository
    {
        UserEntity? ObterPorId(int id);
        IEnumerable<UserEntity>? ObterTodos();
        UserEntity? Adicionar(UserEntity cliente);
        UserEntity? Editar(UserEntity cliente);
        UserEntity? Remover(int id);
    }
}
