using System;

namespace HH.ECommerce.Entities.DTOs
{
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public int OrderId { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Total { get; set; }
    }
}
