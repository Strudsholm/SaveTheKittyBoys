using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class Materialer
    {
        public int Materiale_ID { get; set; }

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
