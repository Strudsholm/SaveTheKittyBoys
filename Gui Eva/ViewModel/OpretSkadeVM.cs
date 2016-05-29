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

        public List<Behandling> b { get; set; }
        public Behandling BehandlingB { get; set; }
        public List<SkadesTyper> s { get; set; }
        public SkadesTyper SkadeTypeS { get; set; }
        public List<Behandling> Behandlinger { get; set; }
        public List<SkadesTyper> SkadesTyper { get; set; }
        public RelayCommand OpretSkadeCommand { get; set; }
        public RelayCommand TilføjskadetypeCommand { get; set; }
        public RelayCommand TilføjBehandlingCommand { get; set; }
        

        public OpretSkadeVM()
        {
            facade = new Facade();
            Skadebind = new Skader();
            SkadesTyper = new List<SkadesTyper>();
            Behandlinger = new List<Behandling>();
            s = new List<SkadesTyper>();
            b = new List<Behandling>();

            //Der er checkrestraint på Frekvens så jeg hardcoder bare værdier i stedet for man selv ska skrive.
            Frekvens = new List<int>();
            Frekvens.Add(1);
            Frekvens.Add(2);
            Frekvens.Add(3);
            Frekvens.Add(4);
            Frekvens.Add(5);

            //Det samme som frekvens
            Aktioner = new List<string>();
            Aktioner.Add("Med det samme");
            Aktioner.Add("Behandlingsplan");
            Aktioner.Add("Tilses om 10år");

            Behandlinger = facade.GetBehandlingsType();
            SkadesTyper = facade.GetSkadesTypers();


            OpretSkadeCommand = new RelayCommand(OpretSkade);
            //TilføjBehandlingCommand = new RelayCommand(TilføjBehandling);
            //TilføjskadetypeCommand = new RelayCommand(TilføjSkadeType);
        }
        //Skal bruges til tilføje behandling og skadestype til skaden. Kan implementeres på næsten samme måde som statuetype.
        //public void TilføjBehandling()
        //{
        //    s.Add(SkadeTypeS);
        //}

        //public void TilføjSkadeType()
        //{
        //    b.Add(BehandlingB);
        //}

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
