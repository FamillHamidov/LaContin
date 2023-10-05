using AutoMapper;
using EntityLayer.Dtos;
using EntityLayer.Entities;

namespace PresentationLayer.Mapper
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<About, AboutDto>().ReverseMap();
        }
    }
}
