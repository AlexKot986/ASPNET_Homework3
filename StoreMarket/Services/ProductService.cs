using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using StoreMarket.Abstroctions;
using StoreMarket.Contexts;
using StoreMarket.Contracts.Requests;
using StoreMarket.Contracts.Responses;
using StoreMarket.Models;

namespace StoreMarket.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public ProductService(StoreContext storeContext, IMapper mapper, IMemoryCache memoryCache)
        {
            _storeContext = storeContext;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public ProductResponse AddProduct(ProductCreateRequest product)
        {
            var entity = _mapper.Map<Product>(product);

            _storeContext.Products.Add(entity);

            _storeContext.SaveChanges();

            _memoryCache.Remove("products");

            return _mapper.Map<ProductResponse>(entity);
        }

        public ProductResponse GetProductId(int id)
        {
            var product = _storeContext.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return null;
            }
            return _mapper.Map<ProductResponse>(product);
        }

        public IEnumerable<ProductResponse> GetProducts()
        {
            if (_memoryCache.TryGetValue("products", out IEnumerable<ProductResponse> prods))
            {
                return prods;
            }

            var products = _storeContext.Products.Select(_mapper.Map<ProductResponse>).ToList();

            _memoryCache.Set("products", products, TimeSpan.FromMinutes(30));

            return products;
        }

        public ProductResponse UpdateProduct(int id, ProductUpdateRequest request)
        {
            var product = _mapper.Map<Product>(request);
            product.Id = id;

            var result = _storeContext.Products.Update(product).Entity;
            _storeContext.SaveChanges();
            _memoryCache.Remove("products");

            return _mapper.Map<ProductResponse>(result);
        }


        public ProductResponse DeleteProduct(int id)
        {
            var result = _storeContext.Products.FirstOrDefault(p => p.Id == id);
            if (result == null)
            {
                return null;
            }
            else
            {
                _storeContext.Products.Remove(result);
                _storeContext.SaveChanges();
                _memoryCache.Remove("products");
                return _mapper.Map<ProductResponse>(result);
            }
        }
    }
}
