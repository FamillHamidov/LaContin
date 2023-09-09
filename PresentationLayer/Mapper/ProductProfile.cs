using AutoMapper;
using EntityLayer.Dtos;
using EntityLayer.Entities;

namespace PresentationLayer.Mapper
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
