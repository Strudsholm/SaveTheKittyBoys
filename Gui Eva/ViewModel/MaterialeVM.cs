using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventmaker.Common;
using Gui_Eva.Model;

namespace Gui_Eva.ViewModel
{
    public class MaterialeVM
    {
        public Facade facade { get; set; }
        public static List<Materiale> MateID  { get; set; }
        public List<Materiale> Sten { get; set; }
        public List<Materiale> Metal { get; set; }
        public List<Materiale> Andet { get; set; }
        public ObservableCollection<Materiale> Stens { get; set; }
        public ObservableCollection<Materiale> Metals { get; set; }
        public ObservableCollection<Materiale> Andets { get; set; }
        public RelayCommand MaterialeCommand { get; set; }
        public int SelIndex { get; set; }

        

        public MaterialeVM()
        {
            facade = new Facade();
            MateID = new List<Materiale>();

            Sten = new List<Materiale>();
            Sten = facade.GetStenList();
            Metal = new List<Materiale>();
            Metal = facade.GetMetalList();
            Andet = new List<Materiale>();
            Andet = facade.GetAndetList();

            int count = 1;
            Stens = new ObservableCollection<Materiale>();
            foreach (var m in Sten)
            {
                Stens.Add(m);
                m.Materiale_Type = "S";
                m.Materiale_ID = count++;
            }
           int cunt = 6;
            Metals = new ObservableCollection<Materiale>();
            foreach (var m in Metal)
            {
                Metals.Add(m);
                m.Materiale_ID = cunt++;
                m.Materiale_Type = "M";
            }
            int cnt = 12;
            Andets = new ObservableCollection<Materiale>();
            foreach (var m in Andet)
            {
                Andets.Add(m);
                m.Materiale_Type = "A";
                m.Materiale_ID = cnt++;
            }
            MaterialeCommand = new RelayCommand(AddMateriale);
        }

        public void AddMateriale()
        {
            MateID.Add(Stens[SelIndex]);
        }
    }
}
