using GLOBAL.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GLOBAL.Data.AppData
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<UserGroupEntity> UserGroup { get; set; }
        public DbSet<DeviceEntity> Device { get; set; }
        public DbSet<DeviceInfoEntity> DeviceInfo { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
    }

}
