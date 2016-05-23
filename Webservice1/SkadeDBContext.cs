namespace Webservice1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SkadeDBContext : DbContext
    {
        public SkadeDBContext()
            : base("name=SkadeDBContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Behandling> Behandling { get; set; }
        public virtual DbSet<Skader> Skader { get; set; }
        public virtual DbSet<SkadesTyper> SkadesTyper { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Behandling>()
                .Property(e => e.BehandlingsType_Navn)
                .IsUnicode(false);

            modelBuilder.Entity<Behandling>()
                .HasMany(e => e.Skader)
                .WithMany(e => e.Behandling)
                .Map(m => m.ToTable("SkadeBehandling").MapLeftKey("BehandlingsType_ID").MapRightKey("Skade_ID"));

            modelBuilder.Entity<Skader>()
                .Property(e => e.Anbefalinger)
                .IsUnicode(false);

            modelBuilder.Entity<Skader>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Skader>()
                .Property(e => e.BehandlingsAktion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SkadesTyper>()
                .Property(e => e.SkadeType_Navn)
                .IsUnicode(false);

            modelBuilder.Entity<SkadesTyper>()
                .HasMany(e => e.Skader)
                .WithMany(e => e.SkadesTyper)
                .Map(m => m.ToTable("SkadeType").MapLeftKey("SkadeType_ID").MapRightKey("Skade_ID"));
        }
    }
}
