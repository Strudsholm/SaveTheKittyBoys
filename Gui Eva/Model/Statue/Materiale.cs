using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class Materiale
    {
        public Materiale()
        {
            StatueMateriale = new HashSet<StatueMateriale>();
        }


        public int Materiale_ID { get; set; }


        public string Materiale_Navn { get; set; }


        public string Materiale_Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatueMateriale> StatueMateriale { get; set; }

        public override string ToString()
        {
            return $"{Materiale_Navn}";
        }
    }
}
