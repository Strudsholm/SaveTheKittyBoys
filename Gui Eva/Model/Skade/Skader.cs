using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class Skader
    {
        public int Skade_ID { get; set; }

        public int Statue_ID { get; set; }

        public int Price { get; set; }

        public string Anbefalinger { get; set; }

    
        public string Notes { get; set; }

       
        public string BehandlingsAktion { get; set; }

        public int? Behandlingfrekvens { get; set; }
    }
}
