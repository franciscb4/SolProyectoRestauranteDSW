using AutoMapper;
using ProyectoRestauranteDSW.DataAccess;
using ProyectoRestauranteDSW.Models;

namespace ProyectoRestauranteDSW.Profiles
{
    public class ReservacionProfile : Profile
    {
        public ReservacionProfile()
        {
            CreateMap<ReservacionEntity, ReservacionModel>()
                 .ForMember(dest => dest.IdReser, opt => opt.MapFrom(src => src.Id))

                 .ReverseMap();
        }
    }
}
