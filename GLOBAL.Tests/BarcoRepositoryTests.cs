using GLOBAL.Data.AppData;
using GLOBAL.Data.Repositories;
using GLOBAL.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GLOBAL.Tests
{
    public class BarcoRepositoryTests
    {
        private readonly DbContextOptions<ApplicationContext> _options;
        private readonly ApplicationContext _context;
        private readonly BarcoRepository _barcoRepository;

        public BarcoRepositoryTests()
        {
        _options = new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "TestDatabase")
                        .Options;

                    _context = new ApplicationContext(_options);
                    _barcoRepository = new BarcoRepository(_context);

        }

        [Fact]
        public void ObterTodos_DeveRetornarListaDeBarcos_QuandoExistiremBarcos()
        {
            _context.Barco.RemoveRange(_context.Barco);
            _context.SaveChanges();
            var barcos = new List<BarcoEntity>
            {
                new BarcoEntity { Nome = "Barco 1", Modelo = "novo", Ano = 1998, Tamanho = 22 },
                new BarcoEntity { Nome = "Barco 2",  Modelo = "velho", Ano = 1999, Tamanho = 100 }
            };
            _context.Barco.AddRange(barcos);
            _context.SaveChanges();

            var resultado = _barcoRepository.ObterTodos();
            Assert.Equal(barcos.Count, resultado.Count());
            Assert.Equal(barcos[0].Nome, resultado.Last().Nome);
            Assert.Equal(barcos[1].Nome, resultado.First().Nome);
        }

        [Fact]
        public void ObterPorId_DeveRetornarBarcoEntity_QuandoBarcoExiste()
        {
            // Arrange
            var barco = new BarcoEntity { Nome = "Barco old", Ano = 2003, Modelo = "velho", Tamanho = 40 };
            _context.Barco.Add(barco);
            _context.SaveChanges();

            // Act
            var resultado = _barcoRepository.ObterPorId(barco.Id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(barco.Id, resultado.Id);
            Assert.Equal(barco.Nome, resultado.Nome);
        }

        [Fact]
        public void Remover_DeveRemoverBarcoERetornarBarcoEntity_QuandoBarcoExiste()
        {
            var barco = new BarcoEntity { Nome = "Neymar barco", Modelo = "antiguidade", Ano = 2024, Tamanho = 45 };
            _context.Barco.Add(barco);
            _context.SaveChanges();

            var resultado = _barcoRepository.Remover(barco.Id);

            var barcoNoDb = _context.Barco.FirstOrDefault(c => c.Id == barco.Id);

            Assert.Null(barcoNoDb);
            Assert.Equal(barco, resultado);
        }

                [Fact]
        public void Adicionar_DeveAdicionarBarcoERetornarBarcoEntity()
        {
            var barco = new BarcoEntity { Nome = "Barco do Igor", Ano = 2000, Modelo = "novinho", Tamanho = 20 };

            var resultado = _barcoRepository.Adicionar(barco);

            var barcoNoDb = _context.Barco.FirstOrDefault(c => c.Id == resultado.Id);
            Assert.NotNull(barcoNoDb);
            Assert.Equal(barco.Nome, barcoNoDb.Nome);
            Assert.Equal(barco.Ano, barcoNoDb.Ano);
            Assert.Equal(barco.Modelo, barcoNoDb.Modelo);
            Assert.Equal(barco.Tamanho, barcoNoDb.Tamanho);
        }

        [Fact]
        public void Editar_DeveAtualizarBarcoERetornarBarcoEntity_QuandoBarcoExiste()
        {
            // Arrange
            var barco = new BarcoEntity { Nome = "Barco viking", Ano = 1999, Modelo = "usado", Tamanho = 15 };
            _context.Barco.Add(barco);
            _context.SaveChanges();

            barco.Nome = "Barco do Jorel";
            barco.Modelo = "novinho";

            // Act
            var resultado = _barcoRepository.Editar(barco);

            // Assert
            var barcoNoDb = _context.Barco.FirstOrDefault(c => c.Id == barco.Id);
            Assert.NotNull(barcoNoDb);
            Assert.Equal("Barco do Jorel", barcoNoDb.Nome);
            Assert.Equal("novinho", barcoNoDb.Modelo);
        }

    }
}
