using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLOBAL.Domain.Entities
{
    [Table("tb_device_info")]
    public class DeviceInfoEntity
  {
        [Key]
        public int Id { get; set; }
        
        [Column("voltage")]
        public Double voltage { get; set; }

        [Column("energyLevel")]
        public int EnergyLevel { get; set; }
    }
}
