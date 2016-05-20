using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class StatueMateriale
    {
        public static List<Materiale> MatID { get; set; }

        public int Materiale_ID { get; set; }
        public int Statue_ID { get; set; }

        public int ID { get; set; }

        public virtual Materiale Materiale { get; set; }

        public virtual Statue Statue { get; set; }
    }
}
