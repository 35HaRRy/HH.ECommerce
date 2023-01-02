using System.ComponentModel.DataAnnotations;

namespace HH.ECommerce.Entities
{
    public class Customer
    {
        public Customer()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string? MiddleName { get; set; }

        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }

        public string FullName { get => $"{FirstName} {MiddleName} {LastName}"; }

        [Required]
        [MaxLength(30)] 
        public string Email { get; set; }

        [Required]
        [MaxLength(13)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(30)]
        public string CustomerType { get; set; }

        public DateTime? DateCreated { get; set; }  
    }
}
