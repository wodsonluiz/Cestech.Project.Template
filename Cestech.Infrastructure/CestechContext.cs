using Cestech.Domain.Entities;
using Cestech.Infrastructure.Maps;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Cestech.Infrastructure
{
    public class CestechContext : DbContext
    {
        public CestechContext(DbContextOptions<CestechContext> options) : base(options)
        {
            Database.Migrate();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=admin123;database=CestechDb");
                //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
