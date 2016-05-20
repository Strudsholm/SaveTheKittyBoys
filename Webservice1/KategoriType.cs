namespace Webservice1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KategoriType")]
    public partial class KategoriType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KategoriType()
        {
            StatueType = new HashSet<StatueType>();
        }

        [Key]
        public int Type_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Type_Navn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatueType> StatueType { get; set; }
    }
}
