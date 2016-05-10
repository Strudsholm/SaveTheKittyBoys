using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class Sten
    {
        public string Marmor { get; set; }

        public Sten()
        {
            Materialer = new HashSet<Materialer>();
        }
    
        public int Sten_ID { get; set; }
   
        public string Sten_Name { get; set; }

        public virtual ICollection<Materialer> Materialer { get; set; }
    }
}
