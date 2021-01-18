using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TheSportsDB.Models.Rahbar;

namespace TheSportsDB.HttpClinet.Rahbar
{
    public class HttpClientLeague
    {
        private readonly HttpClient client;

        private const string BaseAddress = "https://www.thesportsdb.com";

        public HttpClientLeague(HttpClient client)
        {
            this.client = client;
            this.client.BaseAddress = new Uri(BaseAddress);
            this.client.DefaultRequestHeaders.Add("Accept", "application/json");
          
        }
        public List<League> GetLeagues(string c,string s)
        {

            var httpResponse = client.GetAsync($"api/v1/json/1/search_all_leagues.php?c={c}&s={s}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }
            List<League> result;
            using (HttpContent content = httpResponse.Content)
            {

                string stringContent = content.ReadAsStringAsync()
                                               .Result;

                var resultService = JsonSerializer.Deserialize<Countrylst>(stringContent);
                result = resultService.countrys.Select(x => new League { strLeague = x.strLeague,
                strCountry=x.strCountry,
                strSport=x.strSport,
                idLeague=x.idLeague}).ToList();
            }
            return result;

        }
    }
}
