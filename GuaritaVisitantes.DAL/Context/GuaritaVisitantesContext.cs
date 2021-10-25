using GuaritaVisitantes.Entities.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GuaritaVisitantes.DAL.Context
{
    public class GuaritaVisitantesContext : DbContext
    {

        public GuaritaVisitantesContext() : base("name=GuaritaVisitantesContext"){}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Visitante> Visitantes { get; set; }

        public DbSet<EntradasSaidas> EntradasSaidas { get; set; }

        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<VeiculoVisitante> VeiculoVisitantes { get; set; }

        public DbSet<Motorista> Motoristas { get; set; }

        public DbSet<SaidasEntradas> SaidasEntradas { get; set; }

        public DbSet<Notification> Notifications { get; set; }

    }
}
