using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TheSportsDB.Models;
using TheSportsDB.Services;

namespace TheSportsDB.HttpClinet
{
    public class HttpClinetSport
    {
        private readonly HttpClient client;

        private const string BaseAddress = "https://www.thesportsdb.com";
        private IUserRepository repository;

        public HttpClinetSport(HttpClient client, IUserRepository repository)
        {
            this.client = client;
            this.client.BaseAddress = new Uri(BaseAddress);
            this.client.DefaultRequestHeaders.Add("Accept", "application/json");
            this.repository = repository;
        }
        public List<SportName> GetSportName()
        {
            var httpResponse = client.GetAsync("api/v1/json/1/all_sports.php").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }
            List<SportName> result;
            using (HttpContent content = httpResponse.Content)
            {

                string stringContent = content.ReadAsStringAsync()
                                               .Result;

                var resultService = JsonSerializer.Deserialize<SportNameLst>(stringContent);
                result = resultService.sports.Select(x => new SportName { strSport = x.strSport }).ToList();
            }
            return result;
        }
    }
}
