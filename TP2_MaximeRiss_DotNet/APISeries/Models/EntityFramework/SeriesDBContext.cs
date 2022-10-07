

using Microsoft.EntityFrameworkCore;
using APISeries.Models.EntityFramework;

namespace APISeries.Models.EntityFramework
{
    public class SeriesDBContext : DbContext
    {

        public SeriesDBContext(DbContextOptions options) : base(options) {
             
        }


        
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=SeriesDB;uid=postgres;password=postgres;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.HasAnnotation("Relational:Collation", "French_France.1252");

            modelBuilder.Entity<Notation>(entity =>
            {
                entity.HasKey(e => new { e.SerieId, e.UtilisateurId })
                       .HasName("pk_notation");

                entity.HasCheckConstraint("CK_not_notation", "[not_note] >= 0 AND [not_note] <= 0");

                entity.HasOne(d => d.SerieNotee)
                    .WithMany(p => p.NotesSerie)
                    .HasForeignKey(d => d.SerieId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_not_ser");

                entity.HasOne(d => d.UtilisateurNotant)
                    .WithMany(p => p.NotesUtilisateur)
                    .HasForeignKey(d => d.UtilisateurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_not_utl");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.Property(p => p.Pays).HasDefaultValue<string>("France");

                entity.Property(p => p.DateCreation).HasDefaultValueSql("now()");
            });
        }

        public DbSet<APISeries.Models.EntityFramework.Utilisateur> Utilisateur { get; set; }

        public DbSet<APISeries.Models.EntityFramework.Serie>? Serie { get; set; }
    }
}
