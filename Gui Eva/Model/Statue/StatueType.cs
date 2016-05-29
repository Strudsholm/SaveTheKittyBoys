using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class StatueType
    {
        public int Type_ID { get; set; }

       
        public int Statue_ID { get; set; }

     
        public int ID { get; set; }


        public virtual Statue Statue { get; set; }
    }
}
