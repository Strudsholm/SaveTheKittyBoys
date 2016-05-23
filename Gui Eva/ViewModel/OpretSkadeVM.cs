using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventmaker.Common;
using Gui_Eva.Model;

namespace Gui_Eva.ViewModel
{
    public class OpretSkadeVM
    {
        public Facade facade { get; set; }
        public Skader Skadebind { get; set; }
        public Skader Skade { get; set; }
        public List<int> Frekvens { get; set; }
        public List<string> Aktioner { get; set; }
        public int SelectedFrekvens { get; set; }
        public string SelectedAktion { get; set; }

        public List<Behandling> Behandlinger { get; set; }
        public List<SkadesTyper> SkadesTyper { get; set; }
        public RelayCommand OpretSkadeCommand { get; set; }
        

        public OpretSkadeVM()
        {
            facade = new Facade();
            Skadebind = new Skader();
            SkadesTyper = new List<SkadesTyper>();
            Behandlinger = new List<Behandling>();

            Frekvens = new List<int>();
            Frekvens.Add(1);
            Frekvens.Add(2);
            Frekvens.Add(3);
            Frekvens.Add(4);
            Frekvens.Add(5);

            Aktioner = new List<string>();
            Aktioner.Add("Med det samme");
            Aktioner.Add("Behandlingsplan");
            Aktioner.Add("Tilses om 10år");

            Behandlinger = facade.GetBehandlingsType();
            SkadesTyper = facade.GetSkadesTypers();


            OpretSkadeCommand = new RelayCommand(OpretSkade);

        }

        public void OpretSkade()
        {
            Skade = new Skader();

            Skade.Statue_ID = Skadebind.Statue_ID;
            Skade.Anbefalinger = Skadebind.Anbefalinger;
            Skade.BehandlingsAktion = Skadebind.BehandlingsAktion;
            Skade.Behandlingfrekvens = Skadebind.Behandlingfrekvens;
            Skade.Price = Skadebind.Price;
            Skade.Notes = Skadebind.Notes;

            facade.CreateSkade(Skade);
        }
    }
}
