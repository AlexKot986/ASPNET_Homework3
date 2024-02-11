using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StorageFacility.Abstractions;
using StorageFacility.Dto;


namespace WebApplication1.GraphQl
{
    public class Mutation
    {
        private readonly IProductService _productService;

        public Mutation(IProductService productService)
        {
            _productService = productService;
        }
        public ProductResponse PutProduct(int productId, int count)
        {
           return _productService.PutProduct(productId, count);
        }

        public ProductResponse TakeProduct(int productId, int count)
        {
            return _productService.TakeProduct(productId, count);
        }

    }
}
