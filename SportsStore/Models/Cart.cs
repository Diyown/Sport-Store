using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    public class Cart
    {
        [Key]
        public int? Cart_ID { get; set; }
        [Required]
        public string? Product_Name { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal? Price { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public string? TotalPrice { get; set; }
        public string? Status { get; set; }

    }
}
