using ProyectoRestauranteDSW.DataAccess.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRestauranteDSW.DataAccess
{
    [Table("Mesas")]
    public class MesaEntity : Herencia
    {
        public string NroMesa { get; set;}
    }
}
