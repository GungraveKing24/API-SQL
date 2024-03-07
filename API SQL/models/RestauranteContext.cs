using Lab01.models;
using Microsoft.EntityFrameworkCore;

namespace API_SQL.models
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options)
        {
        }

        public DbSet <clientes> Clientes { get; set; }
        public DbSet <pedidos> Pedidos { get; set; }
    }
}
