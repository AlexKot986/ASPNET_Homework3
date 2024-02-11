using System.ComponentModel.DataAnnotations;

namespace StoreMarket.Models
{
    public class Category
    {
        [Key] public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
