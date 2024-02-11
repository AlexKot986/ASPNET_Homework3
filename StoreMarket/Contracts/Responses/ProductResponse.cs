using StoreMarket.Models;

namespace StoreMarket.Contracts.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public int? CategoryId { get; set; }

        //public ProductResponse(Product product)
        //{
        //    Id = product.Id;
        //    Name = product.Name;
        //    Description = product.Description;
        //    Price = product.Price;
        //    CategoryId = product.CategoryId;

        //}

    }
}
