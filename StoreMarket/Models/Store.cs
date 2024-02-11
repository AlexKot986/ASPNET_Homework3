namespace StoreMarket.Models
{
    public class Store
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
