using Microsoft.EntityFrameworkCore;
using API_SQL.models;

namespace API_SQL.Models
{
    public class EquiposContext : DbContext
    {
        public EquiposContext(DbContextOptions<EquiposContext> options) : base(options)
        {

        }

        public DbSet<equipos> Equipos { get; set; }
    }
}
