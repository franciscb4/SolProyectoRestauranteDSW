using ProyectoRestauranteDSW.DataAccess.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRestauranteDSW.DataAccess
{
    [Table("DetalleVenta")]
    public class DetalleVentaEntity : Herencia
    {
        public int Cantidad { get; set; }
        public double Total { get; set; }
        public virtual VentaEntity Venta { get; set; }
        public virtual PlatosEntity Platos { get; set; }
        public virtual UsuariosEntity Usuarios { get; set; }

    }
}
