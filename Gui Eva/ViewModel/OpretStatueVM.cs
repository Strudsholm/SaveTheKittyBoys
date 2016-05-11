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
        public List<String> Placerings { get; set; }
        public List<String> StatueType    { get; set; }
        public Facade facade { get; set; }

        public RelayCommand OpretCommand { get; set; }

        public String NameBind { get; set; }
        public int StatueIDBind { get; set; }
        public string LocationBind { get; set; }
        public string Placeringbind { get; set; }
        public string Typebind { get; set; }
        public string NoteBind { get; set; }
        public string HistoryBind { get; set; }
        public int statueindex { get; set; }
        public int placeringsindex { get; set; }
        //public Sten StenBind { get; set; }
        //public Metal MetalBind { get; set; }
        //public Andet AndetBind { get; set; }
        //public Materialer JjjMaterialer { get; set; }
        public OpretStatueVM()
        {
            facade = new Facade();
            NyStatue = new Statue();
            Placerings = new List<String>();
            Placerings.Add(("Facade"));
            Placerings.Add(("Building"));
            Placerings.Add(("Ground"));

            StatueType = new List<String>();
            StatueType.Add(("Hovede"));
            StatueType.Add(("Ikke hovede"));

            OpretCommand = new RelayCommand(OpretStatue);

            
        }
//Mangler at binde placering + type.
        public void OpretStatue()
        {
            Statue stat = new Statue();

            stat.Name = NyStatue.Name;
            stat.Statue_ID = NyStatue.Statue_ID;
            stat.Location = NyStatue.Location;
            stat.History = NyStatue.History;
            stat.Note = NyStatue.Note;
            stat.Placement = Placerings[placeringsindex];
            stat.Types = StatueType[statueindex].ToString();
            //stat.Materiale = "sten";

            facade.CreateStatue(stat);
        }


    }
}
