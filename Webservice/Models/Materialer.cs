namespace Webservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Materialer")]
    public partial class Materialer
    {
        [Key]
        [Column(Order = 0)]
        public int Materiale_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Statue_ID { get; set; }

        public int? Sten_ID { get; set; }

        public int? Metal_ID { get; set; }

        public int? Andet_ID { get; set; }

        public virtual Andet Andet { get; set; }

        public virtual Metal Metal { get; set; }

        public virtual Statue Statue { get; set; }

        public virtual Sten Sten { get; set; }
    }
}
