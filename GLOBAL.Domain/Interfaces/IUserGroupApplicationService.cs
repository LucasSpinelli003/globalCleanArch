using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces.Dtos;

namespace GLOBAL.Domain.Interfaces
{
    public interface IUserGroupApplicationService
    {
        IEnumerable<UserGroupEntity> ObterTodosUserGroups();
        UserGroupEntity ObterUserGroupPorId(int id);
        UserGroupEntity AdicionarUserGroup(IUserGroupDto entity);
        UserGroupEntity EditarUserGroup(int id, IUserGroupDto entity);
        UserGroupEntity RemoverUserGroup(int id);

    }
}
