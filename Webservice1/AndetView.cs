namespace Webservice1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AndetView")]
    public partial class AndetView
    {
        [Key]
        [StringLength(20)]
        public string Materiale_Navn { get; set; }
    }
}
