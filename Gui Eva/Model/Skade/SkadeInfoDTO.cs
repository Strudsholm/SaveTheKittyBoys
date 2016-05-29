using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class SkadeInfoDTO
    {
        public int SkadeID { get; set; }
        public int StatueID { get; set; }
        public int Pris { get; set; }
        public string Anbefalinger { get; set; }
        public string Noter { get; set; }
        public string BehandlingsAktion { get; set; }
        public string BehandlingsFrekvens { get; set; }
        public string SkadeType { get; set; }
        public string SkadeBehandling { get; set; }

        public override string ToString()
        {
            return $"SkadeID: {SkadeID}, StatueID: {StatueID}, Pris: {Pris}, Anbefalinger: {Anbefalinger}, Noter: {Noter}, BehandlingsAktion: {BehandlingsAktion}, BehandlingsFrekvens: {BehandlingsFrekvens}, SkadeType: {SkadeType}, SkadeBehandling: {SkadeBehandling}";
        }
    }
}
