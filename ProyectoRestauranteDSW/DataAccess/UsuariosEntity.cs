using ProyectoRestauranteDSW.DataAccess.Abstraction;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoRestauranteDSW.DataAccess
{
    [Table("Usuarios")]
    public class UsuariosEntity : Herencia
    {
        public string Nombre { get; set; }
        public string Apellido{ get; set; }

        public string DNI{ get; set; }

        public string Telefono{ get; set; }

        public string Direccion{ get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public bool Rol { get; set; }





    }
}
