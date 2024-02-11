using StoreMarket.Models;

namespace StoreMarket.Contracts.Requests
{
    public class CategoryCreateRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        
        public Category CategoryGetEntity()
        {
            return new Category()
            {
                Name = this.Name,
                Description = this.Description,              
            };
        }
    }
}
