using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
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
        public StatueMateriale NystatueMat { get; set; }
        public List<String> Placerings { get; set; }
        public List<string> Statuetypes { get; set; }
        public List<KategoriType> StatueType    { get; set; }
        public List<KategoriType> StatType { get; set; }
        public KategoriType NyKategoriType { get; set; }
        public StatueType StaType { get; set; }
        public List<Materiale> Sten { get; set; }
        public ObservableCollection<Materiale> Stens { get; set; }
        public List<Materiale> Metal { get; set; }
        public List<Materiale> Andet { get; set; }
        public Facade facade { get; set; }
        public static List<Materiale> MatID { get; set; }
        public int Selindex { get; set; }
        public RelayCommand OpretCommand { get; set; }
        public RelayCommand AddTypeCommand { get; set; }
        public string LocationBind { get; set; }
        public string Placeringbind { get; set; }
        public string Typebind { get; set; }
        public int statueindex { get; set; }
        public int placeringsindex { get; set; }
        public int SelIndex { get; set; }
        public OpretStatueVM()
        {
            facade = new Facade();
            NyStatue = new Statue();
            NystatueMat = new StatueMateriale();
         
            Placerings = new List<String>();
            Placerings.Add(("Facade"));
            Placerings.Add(("Building"));
            Placerings.Add(("Ground"));

            StatueType = new List<KategoriType>();
            StatueType = facade.GetKategoriType();
            StatType = new List<KategoriType>();
            StaType = new StatueType();
            NyKategoriType = new KategoriType();
            OpretCommand = new RelayCommand(OpretStatue);
            AddTypeCommand = new RelayCommand(TilføjType);
            
        }

        public void TilføjType()
        {
           StatType.Add(StatueType[SelIndex]);
        }
        
        public void OpretStatue()
        {
            Statue stat = new Statue();

            stat.Name = NyStatue.Name;
            stat.Statue_ID = NyStatue.Statue_ID;
            stat.Location = NyStatue.Location;
            stat.History = NyStatue.History;
            stat.Note = NyStatue.Note;
            stat.Placement = Placerings[placeringsindex];
            facade.CreateStatue(stat);

            foreach (var i in MaterialeVM.MateID)
            {
                NystatueMat.Materiale_ID = i.Materiale_ID;
                NystatueMat.Statue_ID = stat.Statue_ID;
                facade.CreateStatueMat(NystatueMat);
            }

            foreach (var k in StatType)
            {
                StaType.Statue_ID = stat.Statue_ID;
                StaType.Type_ID = k.Type_ID;
                facade.CreateStatueTyp(StaType);
            }
        }



    }
}
