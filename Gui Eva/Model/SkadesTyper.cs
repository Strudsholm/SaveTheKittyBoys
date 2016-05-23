using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class SkadesTyper
    {
        public int SkadeType_ID { get; set; }

        public string SkadeType_Navn { get; set; }

        public override string ToString()
        {
            return $"{SkadeType_Navn}";
        }
    }
}
