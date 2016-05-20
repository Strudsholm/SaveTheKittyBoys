namespace Webservice1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StenView")]
    public partial class StenView
    {
        [Key]
        [StringLength(20)]
        public string Materiale_Navn { get; set; }
    }
}
