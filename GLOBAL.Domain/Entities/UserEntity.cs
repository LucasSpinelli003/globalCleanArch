using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLOBAL.Domain.Entities
{
    [Table("tb_user")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }

        [Column("isActive")]
        public int IsActive { get; set; }

        [Column("cpf")]
        public String Cpf { get; set; }

        [Column("email")]
        public String Email{ get; set; }

         [Column("password")]
        public String Password{ get; set; }
        
        [Column("userGroupId")]
        public int? UserGroupId { get; set; }
        
        [Column("deviceId")]
        public int? DeviceId { get; set; }
    }
}
