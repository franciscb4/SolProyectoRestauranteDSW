using ProyectoRestauranteDSW.DataAccess;
using System;

namespace ProyectoRestauranteDSW.Models
{
    public class ReservacionModel
    {
        public int IdReser {  get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime HoraReserva { get; set; }
        public int Cantidad { get; set; }
        public string NombreCliente { get; set; }
        public virtual MesaEntity Mesa { get; set; }
    }
}
