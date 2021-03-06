﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Chat;
using Gui_Eva.Model;
using Newtonsoft.Json;

namespace Gui_Eva.ViewModel
{
    public class Facade
    {
        private string serverUrl;
        private HttpClientHandler handler;

        public Boolean svartype { get; set; }

        public Facade()
        {
            handler = new HttpClientHandler();
            serverUrl = "http://localhost:1087/";
            handler.UseDefaultCredentials = true;
            
        }

        /// <summary>
        /// Implementeres i alle facade metoder.
        /// </summary>
        /// 

        public void handlersetup()
        {
            handler = new HttpClientHandler();
            serverUrl = "http://localhost:1087/";
            handler.UseDefaultCredentials = true;
        }
       
        /// <summary>
        /// Henter skade information udfra Statue ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<SkadeInfoDTO> GetSkadeInfoByID(int id)
        {
            handlersetup();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var SkadeInfo = new List<SkadeInfoDTO>();

                try
                {
                    var response = client.GetAsync("api/skader/"+id+"/findbyid").Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var GuestJson = response.Content.ReadAsStringAsync().Result;

                        SkadeInfo = JsonConvert.DeserializeObject<List<SkadeInfoDTO>>(GuestJson);
                        return SkadeInfo;
                    }
                    //Mangler fejlhåndtering
                    return null;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }

        /// <summary>
        /// Henter statueinformation via den metode vi selv har skrevet i controlleren StatuesController Ud fra ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<StatueInfoDTO> GetStatueInfo(int id)
        {
            handlersetup();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var StatueInfo = new List<StatueInfoDTO>();

                try
                {
                    var response = client.GetAsync("api/Statueinfo/"+id).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var GuestJson = response.Content.ReadAsStringAsync().Result;

                        StatueInfo = JsonConvert.DeserializeObject<List<StatueInfoDTO>>(GuestJson);
                        return StatueInfo;
                    }
                    //Mangler fejlhåndtering
                    return null;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }

        /// <summary>
        /// Henter behandlingstyper fra DB returner en List med Behandling objekter
        /// </summary>
        /// <returns></returns>
        public List<Behandling> GetBehandlingsType()
        {
            handlersetup();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var ListOfBehandlingstype = new List<Behandling>();

                try
                {
                    var response = client.GetAsync("api/Behandlings").Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var GuestJson = response.Content.ReadAsStringAsync().Result;

                        ListOfBehandlingstype = JsonConvert.DeserializeObject<List<Behandling>>(GuestJson);

                        return ListOfBehandlingstype;

                    }
                    //Mangler fejlhåndtering
                    return null;
                }
                catch (Exception e)
                {

                    throw e;

                }

            }
        }
        /// <summary>
        /// Henter Skadetyperne fra DB
        /// </summary>
        /// <returns></returns>
        public List<SkadesTyper> GetSkadesTypers()
        {
            handlersetup();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var ListOfSkadestyper = new List<SkadesTyper>();

                try
                {
                    var response = client.GetAsync("api/SkadesTypers").Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var GuestJson = response.Content.ReadAsStringAsync().Result;

                        ListOfSkadestyper = JsonConvert.DeserializeObject<List<SkadesTyper>>(GuestJson);

                        return ListOfSkadestyper;

                    }
                    //Mangler fejlhåndtering
                    return null;
                }
                catch (Exception e)
                {

                    throw e;

                }

            }
        }
        /// <summary>
        /// Indsætter i binde table, så statuen bliver connectet til dens materialer.
        /// </summary>
        /// <param name="nyStatueMateriale"></param>
        /// <returns></returns>
        public async Task CreateStatueMat(StatueMateriale nyStatueMateriale)
        {
            handlersetup();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.PostAsJsonAsync("api/StatueMateriales", nyStatueMateriale);
                    if (response.IsSuccessStatusCode)

                    {

                    }
                }
                catch (Exception)
                {
                    throw;

                }
            }
        }
        /// <summary>
        /// connection mellem statue og type
        /// </summary>
        /// <param name="nyStatueType"></param>
        /// <returns></returns>
        public async Task CreateStatueTyp(StatueType nyStatueType)
        {
            handlersetup();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.PostAsJsonAsync("api/StatueTypes", nyStatueType);
                    if (response.IsSuccessStatusCode)

                    {

                    }
                }
                catch (Exception)
                {
                    throw;

                }
            }
        }
        public List<KategoriType> GetKategoriType()
        {
            handlersetup();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var ListOfTyper = new List<KategoriType>();

                try
                {
                    var response = client.GetAsync("api/KategoriTypes").Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var GuestJson = response.Content.ReadAsStringAsync().Result;

                        ListOfTyper = JsonConvert.DeserializeObject<List<KategoriType>>(GuestJson);

                        return ListOfTyper;

                    }
                    //Mangler fejlhåndtering
                    return null;
                }
                catch (Exception e)
                {

                    throw e;

                }

            }
        }
        public List<Materiale> GetMetalList()
        {
            handlersetup();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var ListOfMetal = new List<Materiale>();

                try
                {
                    var response = client.GetAsync("api/MetalViews").Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var GuestJson = response.Content.ReadAsStringAsync().Result;

                        ListOfMetal = JsonConvert.DeserializeObject<List<Materiale>>(GuestJson);

                        return ListOfMetal;

                    }
                    //Mangler fejlhåndtering
                    return null;
                }
                catch (Exception e)
                {

                    throw e;

                }

            }
        }
        public List<Materiale> GetAndetList()
        {
            handlersetup();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var ListOfAndet = new List<Materiale>();

                try
                {
                    var response = client.GetAsync("api/AndetViews").Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var GuestJson = response.Content.ReadAsStringAsync().Result;

                        ListOfAndet = JsonConvert.DeserializeObject<List<Materiale>>(GuestJson);

                        return ListOfAndet;

                    }
                    //Mangler fejlhåndtering
                    return null;
                }
                catch (Exception e)
                {

                    throw e;

                }

            }
        }
        /// <summary>
        /// Henter StenView fra databasen
        /// </summary>
        /// <returns></returns>
        public List<Materiale> GetStenList()
        {
            handlersetup();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var ListOfSten = new List<Materiale>();

                try
                {
                    var response = client.GetAsync("api/StenViews").Result;
                    if (response.IsSuccessStatusCode)
                    {

                        var GuestJson = response.Content.ReadAsStringAsync().Result;

                        ListOfSten = JsonConvert.DeserializeObject<List<Materiale>>(GuestJson);

                        return ListOfSten;

                    }
                    //Mangler fejlhåndtering
                    return null;
                }
                catch (Exception e)
                {

                    throw e;

                }

            }
        }

        /// <summary>
        /// Vores getmetode for Statuer, henter statuer fra databasen.
        /// </summary>
        /// <returns></returns>
        public List<Statue> GetStatue()
        {
            handlersetup();
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
            handlersetup();
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

       
        /// <summary>
        /// Opretter en statue.
        /// </summary>
        /// <param name="nyStatue"></param>
        /// <returns></returns>
        public async Task CreateStatue(Statue nyStatue)
        {
            handlersetup();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {

                    var response = await client.PostAsJsonAsync("api/Statues", nyStatue);
                    if (response.IsSuccessStatusCode)
                    {
                        
                    }
                    
                }
                catch (Exception)
            {
                throw;

            }
        }

        }
        /// <summary>
        /// Opretter en skade.
        /// </summary>
        /// <param name="nySkade"></param>
        /// <returns></returns>
        public async Task CreateSkade(Skader nySkade)
        {
            handlersetup();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.PostAsJsonAsync("api/Skaders", nySkade);
                    if (response.IsSuccessStatusCode)

                    {

                    }
                }
                catch (Exception)
                {
                    throw;

                }
            }
        }


    }
}
