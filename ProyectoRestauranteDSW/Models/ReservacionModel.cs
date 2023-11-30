using ProyectoRestauranteDSW.DataAccess;
using System;
using System.Collections.Generic;

namespace ProyectoRestauranteDSW.Models
{
    public class ReservacionModel
    {

        public int IdReser {  get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime HoraReserva { get; set; }
        public int Cantidad { get; set; }
        public string NombreCliente { get; set; }
        public List<int> IdsMesas { get; set; }
        public List<MesaEntity> MesasDisponibles { get; set; }
        public string NroMesa { get; set; }

        public ReservacionModel()
        {
            IdsMesas = new List<int>();
            MesasDisponibles = new List<MesaEntity>();
        }

    }
}
