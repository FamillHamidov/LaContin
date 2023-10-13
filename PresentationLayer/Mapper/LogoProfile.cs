using AutoMapper;
using EntityLayer.Dtos;
using EntityLayer.Entities;

namespace PresentationLayer.Mapper
{
    public class LogoProfile:Profile
    {
        public LogoProfile()
        {
            CreateMap<Logo, LogoDto>().ReverseMap();
        }
    }
}
