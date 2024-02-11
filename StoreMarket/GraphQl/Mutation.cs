using Microsoft.AspNetCore.Http.HttpResults;
using StoreMarket.Abstroctions;
using StoreMarket.Contracts.Requests;
using StoreMarket.Contracts.Responses;

namespace WebApplication1.GraphQl
{
    public class Mutation
    {
        private readonly IProductService _productServices;
        private readonly ICategoryService _categoryServices;

        public Mutation(IProductService productServices, ICategoryService categoryServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
        }

        public ProductResponse AddProduct(ProductCreateRequest product)
        {
            return _productServices.AddProduct(product);
        }

        public ProductResponse UpdateProduct(int id, ProductUpdateRequest request)
        {
            return _productServices.UpdateProduct(id, request);
        }

        public ProductResponse DeleteProduct(int id)
        {
            return _productServices.DeleteProduct(id);
        }
        public CategoryResponse AddCategory(CategoryCreateRequest category)
        {
            return _categoryServices.AddCategory(category);
        }

        public CategoryResponse UpdateCategory(int id, CategoryUpdateRequest category)
        {
            return _categoryServices.UpdateCategory(id, category);
        }

        public CategoryResponse DeleteCategory(int id)
        {
            return _categoryServices.DeleteCategory(id);
        }
    }
}
