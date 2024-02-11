using StoreMarket.Contracts.Requests;
using StoreMarket.Contracts.Responses;

namespace StoreMarket.Abstroctions
{
    public interface IProductService
    {
        public ProductResponse AddProduct(ProductCreateRequest product);

        public IEnumerable<ProductResponse> GetProducts();

        public ProductResponse GetProductId(int id);

        public ProductResponse UpdateProduct(int id, ProductUpdateRequest request);

        public ProductResponse DeleteProduct(int id);

    }
}
