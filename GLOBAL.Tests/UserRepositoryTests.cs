using GLOBAL.Data.AppData;
using GLOBAL.Data.Repositories;
using GLOBAL.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GLOBAL.Tests
{
    public class UserRepositoryTests
    {
        private readonly DbContextOptions<ApplicationContext> _options;
        private readonly ApplicationContext _context;
        private readonly UserRepository _userRepository;
        public UserRepositoryTests()
        {
        _options = new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "TestDatabase")
                        .Options;

                    _context = new ApplicationContext(_options);
                    _userRepository = new UserRepository(_context);
        }

        [Fact]
        public void ObterTodos_DeveRetornarListaDeusers_QuandoExistiremBarcos()
        {
            _context.User.RemoveRange(_context.User);
            _context.SaveChanges();
            var users = new List<UserEntity>
            {
                new UserEntity { Name = "User 1", Email = "mail@mail.com", Cpf = "588.969.650-55", IsActive = 1, Password = "any-password", UserGroupId = 1, DeviceId = 1 },
                new UserEntity { Name = "User 2", Email = "mail@mail.com", Cpf = "588.969.650-54", IsActive = 0, Password = "any-password", UserGroupId = 2, DeviceId = 2}
            };
            _context.User.AddRange(users);
            _context.SaveChanges();

            var resultado = _userRepository.ObterTodos();
            Assert.Equal(users.Count, resultado.Count());
            Assert.Equal(users[0].Name, resultado.Last().Name);
            Assert.Equal(users[1].Name, resultado.First().Name);
        }

        [Fact]
        public void ObterPorId_DeveRetornarBarcoEntity_QuandoBarcoExiste()
        {
            // Arrange
            var user = new UserEntity { Name = "User 1", Email = "mail@mail.com", Cpf = "588.969.650-55", IsActive = 1, Password = "any-password", UserGroupId = 1, DeviceId = 1 };
            _context.User.Add(user);
            _context.SaveChanges();

            // Act
            var resultado = _userRepository.ObterPorId(user.Id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(user.Id, resultado.Id);
            Assert.Equal(user.Name, resultado.Name);
        }

        [Fact]
        public void Remover_DeveRemoverBarcoERetornarBarcoEntity_QuandoBarcoExiste()
        {
            var user = new UserEntity { Name = "User 1", Email = "mail@mail.com", Cpf = "588.969.650-55", IsActive = 1, Password = "any-password", UserGroupId = 1, DeviceId = 1 };
            _context.User.Add(user);
            _context.SaveChanges();

            var resultado = _userRepository.Remover(user.Id);

            var userNoDb = _context.User.FirstOrDefault(c => c.Id == user.Id);

            Assert.Null(userNoDb);
            Assert.Equal(user, resultado);
        }

        [Fact]
        public void Adicionar_DeveAdicionarBarcoERetornarBarcoEntity()
        {
            var user = new UserEntity { Name = "User 1", Email = "mail@mail.com", Cpf = "588.969.650-55", IsActive = 1, Password = "any-password", UserGroupId = 1, DeviceId = 1 };

            var resultado = _userRepository.Adicionar(user);

            var userNoDb = _context.User.FirstOrDefault(c => c.Id == resultado.Id);
            Assert.NotNull(userNoDb);
            Assert.Equal(user.Name, userNoDb.Name);
            Assert.Equal(user.Email, userNoDb.Email);
            Assert.Equal(user.DeviceId, userNoDb.DeviceId);
            Assert.Equal(user.Cpf, userNoDb.Cpf);
            Assert.Equal(user.IsActive, userNoDb.IsActive);
            Assert.Equal(user.Password, userNoDb.Password);
            Assert.Equal(user.UserGroupId, userNoDb.UserGroupId);
        }

        [Fact]
        public void Editar_DeveAtualizarBarcoERetornarBarcoEntity_QuandoBarcoExiste()
        {
            // Arrange
            var user = new UserEntity { Name = "User 1", Email = "mail@mail.com", Cpf = "588.969.650-55", IsActive = 1, Password = "any-password", UserGroupId = 1, DeviceId = 1 };
            _context.User.Add(user);
            _context.SaveChanges();

            user.Name = "User 1";
            user.Email = "mail@mail.com";

            // Act
            var resultado = _userRepository.Editar(user);

            // Assert
            var userNoDb = _context.User.FirstOrDefault(c => c.Id == user.Id);
            Assert.NotNull(userNoDb);
            Assert.Equal("User 1", userNoDb.Name);
            Assert.Equal("mail@mail.com", userNoDb.Email);
        }

    }
}
