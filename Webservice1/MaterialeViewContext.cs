namespace Webservice1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MaterialeViewContext : DbContext
    {
        public MaterialeViewContext()
            : base("name=MaterialeViewContext")
        {
        }

        public virtual DbSet<AndetView> AndetView { get; set; }
        public virtual DbSet<MetalView> MetalView { get; set; }
        public virtual DbSet<StenView> StenView { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AndetView>()
                .Property(e => e.Materiale_Navn)
                .IsUnicode(false);

            modelBuilder.Entity<MetalView>()
                .Property(e => e.Materiale_Navn)
                .IsUnicode(false);

            modelBuilder.Entity<StenView>()
                .Property(e => e.Materiale_Navn)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.start_ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.end_ip_address)
                .IsUnicode(false);
        }
    }
}
