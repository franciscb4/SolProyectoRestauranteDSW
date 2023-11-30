using AutoMapper;
using ProyectoRestauranteDSW.DataAccess;
using ProyectoRestauranteDSW.Models;

namespace ProyectoRestauranteDSW.Profiles
{
    public class UsuariosProfilecs : Profile
    {
        public UsuariosProfilecs()
        {
            CreateMap<UsuariosEntity, UsuariosModel>()
                 .ForMember(dest => dest.IdUsu, opt => opt.MapFrom(src => src.Id))

                 .ReverseMap();
        }
    }

}
