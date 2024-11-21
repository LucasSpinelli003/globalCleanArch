using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLOBAL.Domain.Entities
{
    [Table("tb_user_group")]
    public class UserGroupEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }

        [Column("isActive")]
        public int IsActive { get; set; }
    }
}
