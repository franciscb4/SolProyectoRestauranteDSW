using AutoMapper;
using ProyectoRestauranteDSW.DataAccess;
using ProyectoRestauranteDSW.Models;

namespace ProyectoRestauranteDSW.Profiles
{
    public class LocalesProfile : Profile
    {
        public LocalesProfile()
        {
            CreateMap<LocalesEntity, LocalesModel>()
                 .ForMember(dest => dest.IdLocal, opt => opt.MapFrom(src => src.Id))

                 .ReverseMap();
        }
    }
}
