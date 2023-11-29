
using AutoMapper;
using ProyectoRestauranteDSW.DataAccess;
using ProyectoRestauranteDSW.Models;

namespace ProyectoRestauranteDSW.Profiles
{
    public class PlatosProfile : Profile
    {
        public PlatosProfile()
        {
            CreateMap<PlatosEntity, PlatosModel>()
                 .ForMember(dest => dest.IdPlat, opt => opt.MapFrom(src => src.Id))

                 .ReverseMap();
        }
    }
}
