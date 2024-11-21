using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces.Dtos;

namespace GLOBAL.Domain.Interfaces
{
    public interface IUserApplicationService
    {
        IEnumerable<UserEntity> ObterTodosUsers();
        UserEntity ObterUserPorId(int id);
        UserEntity AdicionarUser(IUserDto entity);
        UserEntity EditarUser(int id, IUserDto entity);
        UserEntity RemoverUser(int id);

    }
}
