using Microsoft.EntityFrameworkCore;
using WeDo.Models;

namespace WeDo.Models
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Meta> Metas { get; set; }
        public DbSet<AtividadeDiaria> AtividadesDiarias { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
    }
}
