using ProyectoRestauranteDSW.DataAccess.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRestauranteDSW.DataAccess
{
    [Table("Platos")]
    public class PlatosEntity : Herencia
    {
        public string NombrePlato { get; set; }
        public string Precio { get; set; }
        public string Descripcion { get; set; }

    }
}
