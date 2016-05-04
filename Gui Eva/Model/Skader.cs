using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class Skader
    {
        public int Skade_ID { get; set; }

       
        public int Statue_ID { get; set; }

        public string Types { get; set; }

    
        public string TreatmentAction { get; set; }

        public int? TreatmentFrequency { get; set; }

        public int EstimatedPrice { get; set; }

      
        public string Recomendations { get; set; }

       
        public string Notes { get; set; }

        public virtual Statue Statue { get; set; }
    }
}
