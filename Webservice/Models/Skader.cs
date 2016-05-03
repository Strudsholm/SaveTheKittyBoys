namespace Webservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Skader")]
    public partial class Skader
    {
        [Key]
        [Column(Order = 0)]
        public int Skade_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Statue_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Types { get; set; }

        [Required]
        [StringLength(2)]
        public string TreatmentAction { get; set; }

        public int? TreatmentFrequency { get; set; }

        public int EstimatedPrice { get; set; }

        [StringLength(1)]
        public string Recomendations { get; set; }

        [StringLength(1)]
        public string Notes { get; set; }

        public virtual Statue Statue { get; set; }
    }
}
