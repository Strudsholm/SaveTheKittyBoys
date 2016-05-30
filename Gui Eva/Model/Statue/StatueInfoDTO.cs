using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class StatueInfoDTO
    {
        public int StatueID { get; set; }
        public string statuenavn { get; set; }
        public string location { get; set; }
        public string placement { get; set; }
        public string History { get; set; }
        public string Note { get; set; }
        public string MaterialeType { get; set; }
        public string MaterialeNavn { get; set; }
        public string TypeNavn { get; set; }

        public override string ToString()
        {
            return $"statuenavn: {statuenavn}, location: {location}, placement: {placement}, History: {History}, Note: {Note}, MaterialeNavn: {MaterialeNavn}, TypeNavn: {TypeNavn}";
        }
    }
}
