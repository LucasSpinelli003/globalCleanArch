using GLOBAL.Domain.Entities;

namespace GLOBAL.Domain.Interfaces
{
    public interface IAddressRepository
    {
        AddressEntity? ObterPorId(int id);
        IEnumerable<AddressEntity>? ObterTodos();
        AddressEntity? Adicionar(AddressEntity cliente);
        AddressEntity? Editar(AddressEntity cliente);
        AddressEntity? Remover(int id);
    }
}
