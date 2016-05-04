using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class Andet
    {
        public Andet()
        {
            Materialer = new HashSet<Materialer>();
        }

       
        public int Andet_ID { get; set; }

       
        public string Andet_Name { get; set; }

      
        public virtual ICollection<Materialer> Materialer { get; set; }
    }
}
