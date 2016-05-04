namespace Webservice
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StatueDBContext : DbContext
    {
        public StatueDBContext()
            : base("name=StatueDBContext")
        {
        }

        public virtual DbSet<Andet> Andet { get; set; }
        public virtual DbSet<Materialer> Materialer { get; set; }
        public virtual DbSet<Metal> Metal { get; set; }
        public virtual DbSet<Skader> Skader { get; set; }
        public virtual DbSet<Statue> Statue { get; set; }
        public virtual DbSet<Sten> Sten { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Andet>()
                .Property(e => e.Andet_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Metal>()
                .Property(e => e.Metal_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Skader>()
                .Property(e => e.Types)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Skader>()
                .Property(e => e.TreatmentAction)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Skader>()
                .Property(e => e.Recomendations)
                .IsUnicode(false);

            modelBuilder.Entity<Skader>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Statue>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Statue>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Statue>()
                .Property(e => e.Types)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Statue>()
                .Property(e => e.Placement)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Statue>()
                .Property(e => e.History)
                .IsUnicode(false);

            modelBuilder.Entity<Statue>()
                .Property(e => e.Note)
                .IsUnicode(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.Materialer)
                .WithRequired(e => e.Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.Skader)
                .WithRequired(e => e.Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sten>()
                .Property(e => e.Sten_Name)
                .IsUnicode(false);
        }
    }
}
