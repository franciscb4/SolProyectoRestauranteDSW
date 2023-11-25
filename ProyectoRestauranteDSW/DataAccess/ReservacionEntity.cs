using ProyectoRestauranteDSW.DataAccess.Abstraction;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRestauranteDSW.DataAccess
{
    [Table("Reservas")]
    public class ReservacionEntity: Herencia
    {
        public DateTime FechaReserva { get; set; }
        public DateTime HoraReserva { get; set; }
        public int Cantidad { get; set; }
        public virtual MesaEntity Mesa { get; set; }

    }
}
