using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class Behandling
    {
        public int BehandlingsType_ID { get; set; }

     
        public string BehandlingsType_Navn { get; set; }

        public override string ToString()
        {
            return $"{BehandlingsType_Navn}";
        }
    }
}
