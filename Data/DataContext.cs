using Microsoft.EntityFrameworkCore;
using Practica02Backend.Models;
using Practica02Backend.Models.PerfilesAtributos;

namespace Practica02Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /**Se crean las bases de datos**/
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<PerfilPasatiempos> Pasatiempos { get; set; }
        public DbSet<PerfilFrameworks> PerfilFrameworks { get; set; }
        public DbSet<Nivel> Niveles { get; set; }
        

        /**Este metodo no es necesario pero sirve para construir relaciones de N a N y transformar fechas y/u horas**/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /**modelo para atributos multivaluados**/
            modelBuilder.Entity<PerfilFrameworks>()
            .HasKey(pf => new { pf.perfilId, pf.framework });
            modelBuilder.Entity<PerfilPasatiempos>()
            .HasKey(pf => new { pf.perfilId, pf.pasatiempo });
        }
    }
}
