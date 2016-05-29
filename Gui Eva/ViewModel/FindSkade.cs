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
    class FindSkade
    {
        public Facade facade { get; set; }
        public List<SkadeInfoDTO> SkadeInfo { get; set; }
        public ObservableCollection<SkadeInfoDTO> ObservableSkadeInfo { get; set; }
        public int id { get; set; }
        public RelayCommand HentinfoCommand { get; set; }

        public FindSkade()
        {
            facade = new Facade();
            SkadeInfo = new List<SkadeInfoDTO>();
            ObservableSkadeInfo = new ObservableCollection<SkadeInfoDTO>();

            HentinfoCommand = new RelayCommand(Soeg);
        }

        public void Soeg()
        {
            SkadeInfo = facade.GetSkadeInfoByID(id);

            foreach (var s in SkadeInfo)
            {
                ObservableSkadeInfo.Add(s);
            }
        } 
    }
}
