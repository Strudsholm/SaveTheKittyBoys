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
    public class FindStatueVM
    {

        public Facade facade { get; set; }
        public List<StatueInfoDTO> StatueInfo { get; set; }
        public ObservableCollection<StatueInfoDTO> ObservableStatueInfO { get; set; }
        public int id { get; set; }
        public RelayCommand HentinfoCommand { get; set; }
        public FindStatueVM()
        {
            facade = new Facade();
            StatueInfo = new List<StatueInfoDTO>();
            ObservableStatueInfO = new ObservableCollection<StatueInfoDTO>();

            foreach (var d in StatueInfo)
            {
                ObservableStatueInfO.Add(d);
            }

            HentinfoCommand = new RelayCommand(soeg);
        }

        public void soeg()
        {
            StatueInfo = facade.GetStatueInfo(id);

            foreach (var d in StatueInfo)
            {
                ObservableStatueInfO.Add(d);
            }
        }
    }
}
