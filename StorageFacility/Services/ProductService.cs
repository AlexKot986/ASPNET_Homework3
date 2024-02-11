using AutoMapper;
using StorageFacility.Abstractions;
using StorageFacility.Contexts;
using StorageFacility.Dto;

namespace StorageFacility.Services
{
    public class ProductService : IProductService
    {
        private IMapper _mapper;
        private StorageFacilityContext _context;

        public ProductService(IMapper mapper, StorageFacilityContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<ProductResponse> GetAll()
        {
            var product = _context.Products.Select(_mapper.Map<ProductResponse>).ToList();

            return product;
        }

        public ProductResponse GetProductId(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                return null;
            }
            return _mapper.Map<ProductResponse>(product);

        }

        public ProductResponse PutProduct(int productId, int count)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                return null;
            }
            product.Count += count;
            _context.Products.Update(product);
            _context.SaveChanges();
            return _mapper.Map<ProductResponse>(product);
        }

        public ProductResponse TakeProduct(int productId, int count)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product == null && (product.Count - count) >= 0)
            {
                return null;
            }
            product.Count -= count;
            _context.Products.Update(product);
            _context.SaveChanges();
            return _mapper.Map<ProductResponse>(product);
        }

    }
}
