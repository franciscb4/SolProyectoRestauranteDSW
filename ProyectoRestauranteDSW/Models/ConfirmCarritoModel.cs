using System.Collections.Generic;

namespace ProyectoRestauranteDSW.Models
{
    public class ConfirmCarritoModel
    {
        public string NombreUs { get; set; }
        public string ApellidoUs { get; set; }
        public string DniUs { get; set; }
        public string Telf { get; set; }
        public string DirUs { get; set; }
        public string CorreoUs { get; set; }
        public string ContraUs { get; set; }

        public List<PlatoTemporalModel> TemporalProducts { get; set; }
        public ConfirmCarritoModel()
        {
            TemporalProducts = new List<PlatoTemporalModel>();
        }
    }
}