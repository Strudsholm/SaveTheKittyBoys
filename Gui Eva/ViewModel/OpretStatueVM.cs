using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventmaker.Common;
using Gui_Eva.Model;
using Type = Gui_Eva.Model.Type;

namespace Gui_Eva.ViewModel
{
    public class OpretStatueVM
    {
        public Statue NyStatue { get; set; }
        public List<Placering> Placerings { get; set; }
        public List<Type> StatueType    { get; set; }
        public Facade facade { get; set; }

        public RelayCommand OpretCommand { get; set; }
        
        public string Placeringbind { get; set; }
        public string Typebind { get; set; }
        public string MaterialeBind { get; set; }
        //public Sten StenBind { get; set; }
        //public Metal MetalBind { get; set; }
        //public Andet AndetBind { get; set; }
        //public Materialer JjjMaterialer { get; set; }
        public OpretStatueVM()
        {
            facade = new Facade();
            Placerings = new List<Placering>();
            Placerings.Add(new Placering("Facade"));
            Placerings.Add(new Placering("Building"));
            Placerings.Add(new Placering("Ground"));

            StatueType = new List<Type>();
            StatueType.Add(new Type("Hovede"));
            StatueType.Add(new Type("Ikke hovede"));

            OpretCommand = new RelayCommand(OpretStatue);

            
        }
//Mangler at binde placering + type.
        public void OpretStatue()
        {
            Statue stat = new Statue();

            stat = NyStatue;
            stat.Placement = Placeringbind;
            stat.Types = Typebind;
            stat.Materiale = "sten";

            facade.CreateStatue(stat);
        }


    }
}
