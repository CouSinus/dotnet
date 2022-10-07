using ClientConvertisseurV2.Models;
using Microsoft.UI.Xaml.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;

namespace ClientConvertisseurV2.Services
{
    internal class WSService
    {
        private readonly string getAllDevisePath = "Devise";

        private static WSService instance;

        private static readonly object _lock = new object();

        public static WSService GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    
                    if (instance == null)
                    {
                        instance = new WSService();
                    }
                }
            }
            return instance;
        }



        static HttpClient client;

        static HttpClient Client
        {
            get { return client; }
            set { client = value; }
        }

        public WSService()
        {
            if (client == null) { Client = new HttpClient(); }
            Client.BaseAddress = new Uri("https://localhost:7004/api/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Devise>> GetAllDevisesAsync()
        {
            List<Devise> devise = new List<Devise>();
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await client.GetAsync(getAllDevisePath);
                if (response.IsSuccessStatusCode)
                {
                    devise = await response.Content.ReadFromJsonAsync<List<Devise>>();
                }
            }
            catch(HttpRequestException httpre)
            {
                //exception géré par l'appelant
            }catch(SocketException se)
            {
                //géré par l'appelant
            }
            
            return devise;
        }
    }
}
