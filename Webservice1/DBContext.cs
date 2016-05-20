namespace Webservice1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<KategoriType> KategoriType { get; set; }
        public virtual DbSet<Materiale> Materiale { get; set; }
        public virtual DbSet<Statue> Statue { get; set; }
        public virtual DbSet<StatueMateriale> StatueMateriale { get; set; }
        public virtual DbSet<StatueType> StatueType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KategoriType>()
                .Property(e => e.Type_Navn)
                .IsUnicode(false);

            modelBuilder.Entity<KategoriType>()
                .HasMany(e => e.StatueType)
                .WithRequired(e => e.KategoriType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Materiale>()
                .Property(e => e.Materiale_Navn)
                .IsUnicode(false);

            modelBuilder.Entity<Materiale>()
                .Property(e => e.Materiale_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Materiale>()
                .HasMany(e => e.StatueMateriale)
                .WithRequired(e => e.Materiale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Statue>()
                .Property(e => e.Location)
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
                .HasMany(e => e.StatueMateriale)
                .WithRequired(e => e.Statue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Statue>()
                .HasMany(e => e.StatueType)
                .WithRequired(e => e.Statue)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<Webservice1.MetalView> MetalViews { get; set; }

        public System.Data.Entity.DbSet<Webservice1.StenView> StenViews { get; set; }

        public System.Data.Entity.DbSet<Webservice1.AndetView> AndetViews { get; set; }
    }
}
