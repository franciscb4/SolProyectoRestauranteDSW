using ProyectoRestauranteDSW.DataAccess.Abstraction;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRestauranteDSW.DataAccess
{
    [Table("Venta")]
    public class VentaEntity : Herencia
    {
        public DateTime FechaVenta { get; set; }
        public double MontoTotal { get; set; }
        public virtual UsuariosEntity Usuarios { get; set; }
        public virtual MesaEntity Mesa { get; set; }
        
    }
}
