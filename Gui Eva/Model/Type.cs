using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class Type
    {
        public string type { get; set; }

        public Type(string type)
        {
            this.type = type;
        }

        public override string ToString()
        {
            return $"{type}";
        }
    }
}
