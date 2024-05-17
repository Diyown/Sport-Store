using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    public class Cart
    {
        [Key]
        public long? Cart_ID { get; set; }
        [Required]
        public string? Product_ID { get; set; }
        public string? Product_Name { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal? Price { get; set; }

    }
}
