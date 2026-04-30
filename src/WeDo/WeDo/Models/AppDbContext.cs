using Microsoft.EntityFrameworkCore;

namespace WeDo.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //
            // Local para criar as DbSet para as entidades do projeto, criacao das tabelas e relacionamento entre elas
            //
        }

    }
}
