namespace Webservice1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MetalView")]
    public partial class MetalView
    {
        [Key]
        [StringLength(20)]
        public string Materiale_Navn { get; set; }
    }
}
