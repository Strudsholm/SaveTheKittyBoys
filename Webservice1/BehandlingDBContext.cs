namespace Webservice1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BehandlingDBContext : DbContext
    {
        public BehandlingDBContext()
            : base("name=BehandlingDBContext")
        {
        }

        public virtual DbSet<SkadeBehandling> SkadeBehandling { get; set; }
        public virtual DbSet<SkadeType> SkadeType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
