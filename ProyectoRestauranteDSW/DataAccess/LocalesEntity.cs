using ProyectoRestauranteDSW.DataAccess.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRestauranteDSW.DataAccess
{
    [Table("Locales")]
    public class LocalesEntity : Herencia
    {
        public string NombreLocal { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string URL { get; set; }
    }
}
