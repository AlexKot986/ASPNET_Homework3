using StoreMarket.Models;

namespace StoreMarket.Contracts.Requests
{
    public class CategoryUpdateRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public Category CategoryGetEntity(int id)
        {
            return new Category {Id = id, Name = Name, Description = Description };
        }
    }
}
