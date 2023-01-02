using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HH.ECommerce.Entities
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(35)]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal Rate { get; set; }

        public bool IsRatePercentage { get; set; }
    }
}
