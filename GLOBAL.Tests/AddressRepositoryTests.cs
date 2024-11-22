using GLOBAL.Data.AppData;
using GLOBAL.Data.Repositories;
using GLOBAL.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GLOBAL.Tests
{
    public class AddressRepositoryTests
    {
        private readonly DbContextOptions<ApplicationContext> _options;
        private readonly ApplicationContext _context;
        private readonly AddressRepository _addressRepository;
        public AddressRepositoryTests()
        {
        _options = new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "TestDatabase")
                        .Options;

                    _context = new ApplicationContext(_options);
                    _addressRepository = new AddressRepository(_context);
        }

        [Fact]
        public void ObterTodos_DeveRetornarListaDeAddress_QuandoExistiremAddress()
        {
            _context.Address.RemoveRange(_context.Address);
            _context.SaveChanges();
            var address = new List<AddressEntity>
            {
                new AddressEntity { Neighborhood = "tamanduateí", Number = "353", Street = "rua dos anjos", ZipCode = "03081-003" },
                new AddressEntity { Neighborhood = "barueri", Number = "222", Street = "rua melo freire", ZipCode = "03023-002" },
            };
            _context.Address.AddRange(address);
            _context.SaveChanges();

            var resultado = _addressRepository.ObterTodos();
            Assert.Equal(address.Count, resultado.Count());
            Assert.Equal(address[0].Neighborhood, resultado.First().Neighborhood);
            Assert.Equal(address[1].Neighborhood, resultado.Last().Neighborhood);
        }

        [Fact]
        public void ObterPorId_DeveRetornarAddressEntity_QuandoAddressExiste()
        {
            var address = new AddressEntity { Neighborhood = "tamanduateí", Number = "353", Street = "rua dos anjos", ZipCode = "03081-003" };
            _context.Address.Add(address);
            _context.SaveChanges();

            var resultado = _addressRepository.ObterPorId(address.Id);

            Assert.NotNull(resultado);
            Assert.Equal(address.Neighborhood, resultado.Neighborhood);
            Assert.Equal(address.Number, resultado.Number);
            Assert.Equal(address.Street, resultado.Street);
            Assert.Equal(address.ZipCode, resultado.ZipCode);
        }

        [Fact]
        public void Remover_DeveRemoverAddressERetornarAddressEntity_QuandoAddressExiste()
        {
            var address = new AddressEntity { Neighborhood = "tamanduateí", Number = "353", Street = "rua dos anjos", ZipCode = "03081-003" };;
            _context.Address.Add(address);
            _context.SaveChanges();

            var resultado = _addressRepository.Remover(address.Id);

            var addressNoDb = _context.Address.FirstOrDefault(c => c.Id == address.Id);

            Assert.Null(addressNoDb);
            Assert.Equal(address, resultado);
        }

        [Fact]
        public void Adicionar_DeveAdicionarAddressERetornarAddressEntity()
        {
            var address = new AddressEntity { Neighborhood = "tamanduateí", Number = "353", Street = "rua dos anjos", ZipCode = "03081-003" };

            var resultado = _addressRepository.Adicionar(address);

            var addressNoDb = _context.Address.FirstOrDefault(c => c.Id == resultado.Id);
            Assert.NotNull(addressNoDb);
            Assert.Equal(address.Neighborhood, addressNoDb.Neighborhood);
            Assert.Equal(address.Number, addressNoDb.Number);
            Assert.Equal(address.Street, addressNoDb.Street);
            Assert.Equal(address.ZipCode, addressNoDb.ZipCode);
        }

        [Fact]
        public void Editar_DeveAtualizarAddressERetornarAddressEntity_QuandoAddressExiste()
        {
            var address = new AddressEntity { Neighborhood = "tamanduateí", Number = "353", Street = "rua dos anjos", ZipCode = "03081-003" };
            _context.Address.Add(address);
            _context.SaveChanges();

            address.Neighborhood = "Tatuapé";
            address.Number= "277";
            address.Street= "rua frejos beijos";
            address.ZipCode= "00071-002";

            var resultado = _addressRepository.Editar(address);

            var addressNoDb = _context.Address.FirstOrDefault(c => c.Id == address.Id);
            Assert.NotNull(addressNoDb);
            Assert.Equal("Tatuapé", addressNoDb.Neighborhood);
            Assert.Equal("277", addressNoDb.Number);
            Assert.Equal("rua frejos beijos", addressNoDb.Street);
            Assert.Equal("00071-002", addressNoDb.ZipCode);
        }

    }
}
