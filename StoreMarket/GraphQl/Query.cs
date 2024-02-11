using StoreMarket.Abstroctions;
using StoreMarket.Contracts.Responses;

namespace WebApplication1.GraphQl
{
    public class Query
    {
        private readonly IProductService _productServices;
        private readonly ICategoryService _categoryServices;

        public Query(IProductService productServices, ICategoryService categoryServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
        }

        public IEnumerable<ProductResponse> GetProducts()
        {
            return _productServices.GetProducts();
        }

        public ProductResponse GetProductId(int id)
        {
            return _productServices.GetProductId(id);
        }

        public IEnumerable<CategoryResponse> GetCategories()
        {
            return _categoryServices.GetCategories();
        }

        public CategoryResponse GetCategoryId(int id)
        {
            return _categoryServices.GetCategoryId(id);
        }
    }
}
