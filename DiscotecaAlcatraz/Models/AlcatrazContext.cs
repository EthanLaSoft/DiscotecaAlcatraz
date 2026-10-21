using System.Data.Entity;

namespace DiscotecaAlcatraz.Models
{
    public class AlcatrazContext : DbContext
    {
        public AlcatrazContext()
            : base("name=AlcatrazContext")
        {
        }

        public DbSet<Evento> Eventos { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(
            DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reserva>()
                .HasRequired(r => r.Evento)
                .WithMany(e => e.Reservas)
                .HasForeignKey(r => r.EventoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reserva>()
                .Property(r => r.ValorTotal)
                .HasPrecision(10, 2);
        }
    }
}