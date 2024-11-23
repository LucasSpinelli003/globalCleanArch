using GLOBAL.Domain.Entities;
using GLOBAL.Domain.Interfaces;
using GLOBAL.Domain.Interfaces.Dtos;

namespace GLOBAL.Application.Services
{
    public class AddressApplicationService : IAddressApplicationService
    {
        private readonly IAddressRepository _repository;

        public AddressApplicationService(IAddressRepository repository)
        {
            _repository = repository;
        }

        public AddressEntity AdicionarAddress(IAddressDto entity)
        {
            return _repository.Adicionar(new AddressEntity
            {
                Neighborhood = entity.Neighborhood,
                Number = entity.Number,
                Street = entity.Street,
                ZipCode = entity.ZipCode
            });

        }

        public AddressEntity EditarAddress(int id, IAddressDto entity)
        {
              return _repository.Editar(new AddressEntity
            {
                Id = id,
                Neighborhood = entity.Neighborhood,
                Number = entity.Number,
                Street = entity.Street,
            });

        }

        public AddressEntity ObterAddressPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<AddressEntity>? ObterTodosAddresss()
        {
            return _repository.ObterTodos();
        }

        public AddressEntity RemoverAddress(int id)
        {
            return _repository.Remover(id);
        }
    }
}
