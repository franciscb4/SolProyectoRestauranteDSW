using ProyectoRestauranteDSW.DataAccess.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRestauranteDSW.DataAccess
{
    [Table("Platos")]
    public class PlatosEntity : Herencia
    {
        public string NombrePlato { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }

    }
}