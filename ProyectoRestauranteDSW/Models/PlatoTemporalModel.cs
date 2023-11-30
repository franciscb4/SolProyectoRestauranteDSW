namespace ProyectoRestauranteDSW.Models
{
    public class PlatoTemporalModel
    {
        public int Id { get; set; }
        public string PlatoName { get; set; }
        public double PlatoPrice { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }= 0;
        public string Img { get; set; }
    }
}