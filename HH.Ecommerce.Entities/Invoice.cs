using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HH.ECommerce.Entities
{
    public class Invoice
    {
        public Invoice()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        public int InvoiceId { get; set; }

        [Required]
        [MaxLength(25)]
        public string InvoiceNumber { get; set; }

        [Required]
        [MaxLength(25)]
        public int OrderId { get; set; }

        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal OrderTotal { get; set; }
        public DateTime DateCreated { get; set; }

        [Required]
        [Column(TypeName = "decimal(19, 2)")]
        public decimal Total { get; set; }


        [ForeignKey(nameof(Customers))]
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }

        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
