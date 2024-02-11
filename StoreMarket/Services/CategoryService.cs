using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Caching.Memory;
using StoreMarket.Abstroctions;
using StoreMarket.Contexts;
using StoreMarket.Contracts.Requests;
using StoreMarket.Contracts.Responses;
using StoreMarket.Models;

namespace StoreMarket.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly StoreContext _storeContext;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public CategoryService(StoreContext storeContext, IMapper mapper, IMemoryCache memoryCache)
        {
            _storeContext = storeContext;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public CategoryResponse AddCategory(CategoryCreateRequest category)
        {
            var entity = _mapper.Map<Category>(category);

            _storeContext.Categories.Add(entity);

            _storeContext.SaveChanges();

            _memoryCache.Remove("categories");

            return _mapper.Map<CategoryResponse>(entity);
        }

        public CategoryResponse DeleteCategory(int id)
        {
            var result = _storeContext.Categories.FirstOrDefault(p => p.Id == id);
            if (result == null)
            {
                return null;
            }
            else
            {
                _storeContext.Categories.Remove(result);
                _storeContext.SaveChanges();
                _memoryCache.Remove("categories");
                return _mapper.Map<CategoryResponse>(result);
            }
        }

        public IEnumerable<CategoryResponse> GetCategories()
        {
            if (_memoryCache.TryGetValue("categories", out IEnumerable<CategoryResponse> categoriesCashe))
            {
                return categoriesCashe;
            }

            var categories = _storeContext.Categories.Select(_mapper.Map<CategoryResponse>).ToList();

            _memoryCache.Set("categories", categories, TimeSpan.FromMinutes(30));

            return categories;
        }

        public CategoryResponse GetCategoryId(int id)
        {
            var category = _storeContext.Categories.FirstOrDefault(p => p.Id == id);

            if (category == null)
            {
                return null;
            }
            return _mapper.Map<CategoryResponse>(category);

        }

        public CategoryResponse UpdateCategory(int id, CategoryUpdateRequest category)
        {
            var categoryResult = _mapper.Map<Category>(category);
            categoryResult.Id = id;

            var result = _storeContext.Categories.Update(categoryResult).Entity;
            _storeContext.SaveChanges();
            _memoryCache.Remove("categories");

            return _mapper.Map<CategoryResponse>(result);
        }
    }
}
