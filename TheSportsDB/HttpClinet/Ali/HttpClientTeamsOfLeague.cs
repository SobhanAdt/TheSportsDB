using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TheSportsDB.Models.Ali;

namespace TheSportsDB.HttpClinet.Ali
{
    
    public class HttpClientTeamsOfLeague
    {
        private readonly HttpClient client;
        private const string BaseAddress = "https://www.thesportsdb.com";
        public HttpClientTeamsOfLeague(HttpClient client)
        {
            this.client = client;
            this.client.BaseAddress = new Uri(BaseAddress);
            this.client.DefaultRequestHeaders
                       .Add("Accept", "application/json");
        }
        public List<TeamsOfLeagueName> GetLeaguestr(string query)
        {
            try
            {
                var httpResponse = client.GetAsync($"api/v1/json/1/search_all_teams.php?l={query}").Result;
                httpResponse.EnsureSuccessStatusCode();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    return null;
                }
                List<TeamsOfLeagueName> result;
                using (HttpContent content = httpResponse.Content)
                {

                    string stringContent = content.ReadAsStringAsync()
                                                   .Result;

                    var resultService = JsonSerializer.Deserialize<TeamsOfLeagueList>(stringContent);


                    result = resultService.teams.Select(x => new TeamsOfLeagueName()
                    {
                        Id = x.idLeague,
                        LeagueName = x.strLeague,
                        TeamName = x.strTeam
                    }).ToList();

                }
                return result;
            }
            catch(Exception)
            {
                throw new Exception("Invalid Input");
            }
        }
    } 
}

