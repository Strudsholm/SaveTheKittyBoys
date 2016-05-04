using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Gui_Eva.Model;
using Newtonsoft.Json;

namespace Gui_Eva.ViewModel
{
    public class Facade
    {
        private string serverUrl;
        private HttpClientHandler handler;

        public Facade()
        {
            handler = new HttpClientHandler();
            serverUrl = "http://localhost:5049/";
            handler.UseDefaultCredentials = true;
        }

        /// <summary>
        /// Vores getmetode for Statuer, henter statuer fra databasen.
        /// </summary>
        /// <returns></returns>
        public List<Statue> GetStatue()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var ListOfStatue = new List<Statue>();

                try
                {
                    var response = client.GetAsync("api/Statues").Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var GuestJson = response.Content.ReadAsStringAsync().Result;

                        ListOfStatue = JsonConvert.DeserializeObject<List<Statue>>(GuestJson);

                        return ListOfStatue;

                    }
                    //Mangler fejlhåndtering
                    return null;
                }
                catch (Exception)
                {
                    throw;

                }

            }
        }
        /// <summary>
        /// Vores getmetode for skader, henter skader fra databasen.
        /// </summary>
        /// <returns></returns>
        public List<Skader> GetSkade()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var ListOfSkader = new List<Skader>();

                try
                {
                    var response = client.GetAsync("api/Statues").Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var GuestJson = response.Content.ReadAsStringAsync().Result;

                        ListOfSkader = JsonConvert.DeserializeObject<List<Skader>>(GuestJson);

                        return ListOfSkader;

                    }
                    //Mangler fejlhåndtering
                    return null;
                }
                catch (Exception)
                {
                    throw;

                }
            }
        }


    }
}
