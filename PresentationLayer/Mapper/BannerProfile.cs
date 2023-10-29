using AutoMapper;
using EntityLayer.Dtos;
using EntityLayer.Entities;

namespace PresentationLayer.Mapper
{
    public class BannerProfile:Profile
    {
        public BannerProfile()
        {
            CreateMap<BannerPicture, BannerPictureDto>().ReverseMap();
        }
    }
}
