namespace Webservice1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Materiale")]
    public partial class Materiale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Materiale()
        {
            StatueMateriale = new HashSet<StatueMateriale>();
        }

        [Key]
        public int Materiale_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Materiale_Navn { get; set; }

        [Required]
        [StringLength(20)]
        public string Materiale_Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatueMateriale> StatueMateriale { get; set; }
    }
}
