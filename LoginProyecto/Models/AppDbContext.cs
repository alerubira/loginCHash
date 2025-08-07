using Microsoft.EntityFrameworkCore;
using LoginProyecto.Models; // 👈 Esto importa Usuario

namespace LoginProyecto.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}

