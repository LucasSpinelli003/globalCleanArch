using GLOBAL.Data.AppData;
using GLOBAL.Data.Repositories;
using GLOBAL.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GLOBAL.Tests
{
    public class UserGroupRepositoryTests
    {
        private readonly DbContextOptions<ApplicationContext> _options;
        private readonly ApplicationContext _context;
        private readonly UserGroupRepository _userGroupRepository;
        
        public UserGroupRepositoryTests()
        {
        _options = new DbContextOptionsBuilder<ApplicationContext>()
                        .UseInMemoryDatabase(databaseName: "TestDatabase")
                        .Options;

                    _context = new ApplicationContext(_options);
                    _userGroupRepository = new UserGroupRepository(_context);
        }

        [Fact]
        public void ObterTodos_DeveRetornarListaDeUserGroup_QuandoExistiremUserGroups()
        {
            _context.UserGroup.RemoveRange(_context.UserGroup);
            _context.SaveChanges();
            var userGroups = new List<UserGroupEntity>
            {
                new UserGroupEntity { IsActive = 0, Name = "first" },
                new UserGroupEntity { IsActive = 1,  Name = "second" }
            };
            _context.UserGroup.AddRange(userGroups);
            _context.SaveChanges();

            var resultado = _userGroupRepository.ObterTodos();
            Assert.Equal(userGroups.Count, resultado.Count());
            Assert.Equal(userGroups[0].Name, resultado.First().Name);
            Assert.Equal(userGroups[1].IsActive, resultado.Last().IsActive);
        }

        [Fact]
        public void ObterPorId_DeveRetornarUserGroupEntity_QuandoUserGroupExiste()
        {
            // Arrange
            var userGroup = new UserGroupEntity { Name = "first", IsActive = 1 };
            _context.UserGroup.Add(userGroup);
            _context.SaveChanges();

            // Act
            var resultado = _userGroupRepository.ObterPorId(userGroup.Id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(userGroup.Name, resultado.Name);
            Assert.Equal(userGroup.IsActive, resultado.IsActive);
        }

        [Fact]
        public void Remover_DeveRemoverUserGroupERetornarUserGroupEntity_QuandoUserGroupExiste()
        {
            var userGroup = new UserGroupEntity { Name = "first", IsActive = 1 };
            _context.UserGroup.Add(userGroup);
            _context.SaveChanges();

            var resultado = _userGroupRepository.Remover(userGroup.Id);

            var userGroupNoDb = _context.UserGroup.FirstOrDefault(c => c.Id == userGroup.Id);

            Assert.Null(userGroupNoDb);
            Assert.Equal(userGroup, resultado);
        }

        [Fact]
        public void Adicionar_DeveAdicionarUserGroupERetornarUserGroupEntity()
        {
            var userGroup = new UserGroupEntity { Name = "first", IsActive = 1 };

            var resultado = _userGroupRepository.Adicionar(userGroup);

            var userGroupNoDb = _context.UserGroup.FirstOrDefault(c => c.Id == resultado.Id);
            Assert.NotNull(userGroupNoDb);
            Assert.Equal(userGroup.IsActive, userGroupNoDb.IsActive);
            Assert.Equal(userGroup.Name, userGroupNoDb.Name);
        }

        [Fact]
        public void Editar_DeveAtualizarUserGroupERetornarUserGroupEntity_QuandoUserGroupExiste()
        {
            // Arrange
            var userGroup = new UserGroupEntity { Name = "first", IsActive = 1 };
            _context.UserGroup.Add(userGroup);
            _context.SaveChanges();

            userGroup.IsActive = 0;
            userGroup.Name = "group 1";

            // Act
            var resultado = _userGroupRepository.Editar(userGroup);

            // Assert
            var userGroupNoDb = _context.UserGroup.FirstOrDefault(c => c.Id == userGroup.Id);
            Assert.NotNull(userGroupNoDb);
            Assert.Equal(0, userGroupNoDb.IsActive);
            Assert.Equal("group 1", userGroupNoDb.Name);
        }

    }
}
