using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class Placering
    {
        public string placering { get; set; }

        public Placering(string placering)
        {
            this.placering = placering;
        }

        public override string ToString()
        {
            return $"{placering}";
        }
    }
}
