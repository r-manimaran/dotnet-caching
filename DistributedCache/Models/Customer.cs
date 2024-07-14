using System.ComponentModel.DataAnnotations;

namespace DistributedCache.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; init; }
        [Required]
        public string Name { get; init; }
        [Required]
        public string Street { get; init; }
        [Required]
        public string City { get; init; }
        [Required]
        public string State { get; init; }
        [Required]
        [RegularExpression("^([0-9]{5})$")]
        public string Zipcode { get; init; }
        [Required]
        public string Phone { get; init; }
        [Required]
        [EmailAddress]
        public string Email { get; init; }
    }
}
