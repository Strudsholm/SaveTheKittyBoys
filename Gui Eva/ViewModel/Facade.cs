using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Eva.ViewModel
{
    public class Facade
    {
        string serverUrl;
        private HttpClientHandler handler;

        public Facade()
        {
            handler = new HttpClientHandler();
            serverUrl = "http://localhost:24061/";
            handler.UseDefaultCredentials = true;


        }
    }
}
