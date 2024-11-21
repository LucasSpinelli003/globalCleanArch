using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLOBAL.Domain.Entities
{
    [Table("tb_user_address")]
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Column("street")]
        public String Street { get; set; }

        [Column("number")]
        public String Number { get; set; }

        [Column("neighborhood")]
        public String Neighborhood { get; set; }

        [Column("zipCode")]
        public String ZipCode { get; set; }
    }
}
