using AutoMapper;
using StorageFacility.Contexts;
using StorageFacility.Dto;

namespace StorageFacility.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
        }
    }
}
