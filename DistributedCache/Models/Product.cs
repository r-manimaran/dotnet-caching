using System.ComponentModel.DataAnnotations;

namespace DistributedCache.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string ProductCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(1,900)]
        public decimal Price { get; set; }
        [Required]
        [Range(1,5000)]
        public int StockAvailable { get; set; }
    }
}
