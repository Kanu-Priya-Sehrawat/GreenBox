using System.Linq;
using AutoMapper;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
           
            CreateMap<Plastic, PlasticDto>().ReverseMap();

            CreateMap<Photo, PhotoDto>().ReverseMap();

            CreateMap<Plastic, PlasticListDto>()
                .ForMember(d => d.PlasticType, opt => opt.MapFrom(src => src.PlasticType.Name))
                .ForMember(d => d.Photo, opt => opt.MapFrom(src => src.Photos
                                .FirstOrDefault(p => p.IsPrimary).ImageUrl))
                .ForMember(d => d.quantity, opt => opt.MapFrom(src => src.quantity)); 


            CreateMap<PlasticType, KeyValuePairDto>();            

        }
        
    }
}