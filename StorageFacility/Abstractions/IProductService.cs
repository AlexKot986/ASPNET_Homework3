using StorageFacility.Dto;

namespace StorageFacility.Abstractions
{
    public interface IProductService
    {
        ProductResponse TakeProduct(int productId, int count);
        ProductResponse PutProduct(int productId, int count);
        IEnumerable<ProductResponse> GetAll();
        ProductResponse GetProductId(int productId);
    }
}
