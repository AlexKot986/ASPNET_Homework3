using StoreMarket.Contracts.Requests;
using StoreMarket.Contracts.Responses;

namespace StoreMarket.Abstroctions
{
    public interface ICategoryService
    {
        public CategoryResponse AddCategory(CategoryCreateRequest category);

        public IEnumerable<CategoryResponse> GetCategories();

        public CategoryResponse GetCategoryId(int id);

        public CategoryResponse UpdateCategory(int id, CategoryUpdateRequest category);

        public CategoryResponse DeleteCategory(int id);
    }
}
