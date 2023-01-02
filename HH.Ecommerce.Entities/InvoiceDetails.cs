using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HH.ECommerce.Entities
{
    public class InvoiceDetails
    {
        [Key]        
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }


        [Required]
        public bool IsGroceries { get; set; }

        [Required]
        [MaxLength(30)]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(30)]
        public decimal ProductPrice { get; set; }

        [Required]
        [MaxLength(30)]
        public int ProductQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal DerivedProductCost { get; set; } 

        [Column(TypeName = "decimal(19, 2)")]
        public decimal DiscountPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal TotalDerivedCost { get; set; }

        [ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; } 
    }
}
