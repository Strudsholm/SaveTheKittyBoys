namespace Webservice1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Skader")]
    public partial class Skader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Skader()
        {
            Behandling = new HashSet<Behandling>();
            SkadesTyper = new HashSet<SkadesTyper>();
        }

        [Key]
        public int Skade_ID { get; set; }

        public int Statue_ID { get; set; }

        public int Price { get; set; }

        [StringLength(200)]
        public string Anbefalinger { get; set; }

        [StringLength(200)]
        public string Notes { get; set; }

        [Required]
        [StringLength(25)]
        public string BehandlingsAktion { get; set; }

        public int? Behandlingfrekvens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Behandling> Behandling { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkadesTyper> SkadesTyper { get; set; }
    }
}
