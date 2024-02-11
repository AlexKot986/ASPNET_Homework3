using StoreMarket.Models;

namespace StoreMarket.Contracts.Requests
{
    public class ProductUpdateRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public int? CategoryId { get; set; }

        public Product ProductGetEntity(int id)
        {

            return new Product()
            {
                Id = id,
                Name = Name,
                Description = Description,
                Price = Price,
                CategoryId = CategoryId
            };
        }
    }
}
