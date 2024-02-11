using AutoMapper;
using StoreMarket.Contracts.Requests;
using StoreMarket.Contracts.Responses;
using StoreMarket.Models;

namespace StoreMarket.Mappers 
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>(MemberList.Destination).ReverseMap();
            CreateMap<Product, ProductUpdateRequest>(MemberList.Destination).ReverseMap();
            CreateMap<Product, ProductCreateRequest>(MemberList.Destination).ReverseMap();

            CreateMap<Category, CategoryResponse>(MemberList.Destination).ReverseMap();
            CreateMap<Category, CategoryUpdateRequest>(MemberList.Destination).ReverseMap();
            CreateMap<Category, CategoryCreateRequest>(MemberList.Destination).ReverseMap();
        }
    }
}
