using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.Model
{
    public class KategoriType
    {
        public KategoriType()
        {
            StatueType = new HashSet<StatueType>();
        }

   
        public int Type_ID { get; set; }


        public string Type_Navn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatueType> StatueType { get; set; }

        public override string ToString()
        {
            return $"{Type_Navn}";
        }
    }
}
