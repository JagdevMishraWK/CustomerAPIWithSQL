using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerWebAPI.Models
{
    [Table("customer",Schema ="dbo")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Column("customer_name")]
        public string Name { get; set; }
        [Column("customer_email")]
        public string Email { get; set; }
        [Column("customer_phone")]
        public string Phone { get; set; }
    }
}
