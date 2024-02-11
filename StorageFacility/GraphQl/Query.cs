

using Microsoft.EntityFrameworkCore;
using StorageFacility.Abstractions;
using StorageFacility.Dto;

namespace WebApplication1.GraphQl
{
    public class Query
    {
        private readonly IProductService _productService;
        public Query(IProductService productService)
        {
            _productService = productService;
        }

        public IEnumerable<ProductResponse> GetAll()
        {
            return _productService.GetAll();
        }
        public ProductResponse GetProductId(int productId)
        {
            return _productService.GetProductId(productId);
        }

    }
}
