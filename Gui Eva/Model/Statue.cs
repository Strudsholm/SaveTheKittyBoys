using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class Statue
    {
        public Statue()
        {
            Materialer = new HashSet<Materialer>();
            Skader = new HashSet<Skader>();
        }

       
        public int Statue_ID { get; set; }

      
        public string Name { get; set; }

        
        public string Location { get; set; }

        public string Types { get; set; }

       
        public string Placement { get; set; }

    
        public string History { get; set; }

       
        public string Note { get; set; }

       
        public virtual ICollection<Materialer> Materialer { get; set; }

     
        public virtual ICollection<Skader> Skader { get; set; }
    }
}
