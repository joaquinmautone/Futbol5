using System;
using System.Data.Entity;
using System.Linq;
using Futbol5.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Futbol5.DAL
{
    public class Futbol5Entities : DbContext
    {
        public Futbol5Entities() : base("name=Futbol5Entities")
        {

        }

        public virtual DbSet<Campeonato> Campeonatos { get; set; }
        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Jugador> Jugadores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Campeonato>()
            //    .HasMany(c => c.Equipos)
            //    .WithMany(e => e.Campeonatos)
            //    .Map(m =>
            //    {
            //        m.ToTable("CampeonatosEquipos");
            //        m.MapLeftKey("CampeonatoId");
            //        m.MapRightKey("EquipoId");
            //    });

            //modelBuilder.Entity<Equipo>()
            //    .HasMany(e => e.Jugadores)
            //    .WithRequired(j => j.Equipo)
            //    .WillCascadeOnDelete();
        }
    }

    public class Futbol5DbInitializer : DropCreateDatabaseIfModelChanges<Futbol5Entities>
    {

    }
}