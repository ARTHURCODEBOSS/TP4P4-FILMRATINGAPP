using FilmRatingsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FilmRatingsApp.Services
{
    public class WSService: IService
    {
        private HttpClient client;

        public HttpClient Client
        {
            get { return client; }
            set { client = value; }
        }
        public WSService()
        {
            Client = new HttpClient();
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5000/api/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Utilisateur> GetUtilisateurByEmailAsync(string email)
        {
            try
            {
                return await Client.GetFromJsonAsync<Utilisateur>($"utilisateurs/GetUtilisateurByEmail/{email}");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
