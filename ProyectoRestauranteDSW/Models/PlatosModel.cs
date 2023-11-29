namespace ProyectoRestauranteDSW.Models
{
    public class PlatosModel
    {
        public int IdPlat { get; set; } 
        public string NombrePlato { get; set; }
        public double Precio { get; set; } = 0;
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    }
}
