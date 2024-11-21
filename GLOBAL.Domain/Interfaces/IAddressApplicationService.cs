using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces.Dtos;

namespace GLOBAL.Domain.Interfaces
{
    public interface IAddressApplicationService
    {
        IEnumerable<AddressEntity> ObterTodosAddresss();
        AddressEntity ObterAddressPorId(int id);
        AddressEntity AdicionarAddress(IAddressDto entity);
        AddressEntity EditarAddress(int id, IAddressDto entity);
        AddressEntity RemoverAddress(int id);

    }
}
