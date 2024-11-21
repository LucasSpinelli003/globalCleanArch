using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLOBAL.Domain.Entities
{
    [Table("tb_device")]
    public class DeviceEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }

        [Column("deviceInfoId")]
        public int DeviceInfoId { get; set; }
    }
}
