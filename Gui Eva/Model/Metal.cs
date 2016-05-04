using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class Metal
    {
        public Metal()
        {
            Materialer = new HashSet<Materialer>();
        }

        public int Metal_ID { get; set; }

        public string Metal_Name { get; set; }
        public virtual ICollection<Materialer> Materialer { get; set; }
    }
}
