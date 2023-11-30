namespace ProyectoRestauranteDSW.Models
{
    public class UsuariosModel
    {
        public int IdUsu { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string DNI { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public bool Rol { get; set; }

    }
}
