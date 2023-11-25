using Microsoft.EntityFrameworkCore;

namespace ProyectoRestauranteDSW.DataAccess
{
    public class RestauranteContext : DbContext
    {
        public DbSet<UsuariosEntity> Usuario { get; set; }
        public DbSet<PlatosEntity> Plato { get; set; }
        public DbSet<MesaEntity> Mesa { get; set; }
        public DbSet<ReservacionEntity>Reserva  { get; set; }
        public DbSet<VentaEntity> Venta { get; set; }
        public DbSet<DetalleVentaEntity> DetalleVenta { get; set; }
        public DbSet<LocalesEntity> Local { get; set; }
        public RestauranteContext(DbContextOptions<RestauranteContext> option) : base(option)
        {
            

        }

    }
}
