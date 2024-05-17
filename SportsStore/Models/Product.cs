using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace SportsStore.Models
{
    public class Product
    {
        [Key]
        public long? Product_ID { get; set; }
        [Required]
        public string? Product_Name { get; set; }
        public string? Product_Desc { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal? Price { get; set; }
        public string? Product_Category { get; set;}

    }
}
