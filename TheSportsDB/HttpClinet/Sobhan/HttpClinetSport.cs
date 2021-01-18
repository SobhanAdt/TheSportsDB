using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using TheSportsDB.Models;
using TheSportsDB.Models.Sobhan;
using TheSportsDB.Services;
using static TheSportsDB.Models.TeamName;

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
            try
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
            catch (Exception)
            {

                throw new Exception("your request has problem!");
            }
        }


        public List<TeamName> GetTeamByName(string teamName)
        {
            try
            {
                var httpResponse = client.GetAsync($"api/v1/json/1/searchteams.php?t={teamName}").Result;
                httpResponse.EnsureSuccessStatusCode();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    return null;
                }

                List<TeamName> result;
                using (HttpContent content = httpResponse.Content)
                {

                    string stringContent = content.ReadAsStringAsync()
                        .Result;

                    var resultService = JsonSerializer.Deserialize<TeamList>(stringContent);
                    var resulTeamNames = resultService.teams.Select(x => new TeamName()
                    {
                        Team = x.strTeam,
                        Alternate = x.strAlternate,
                        DescriptionEN = x.strDescriptionEN,
                        FormedYear = x.intFormedYear,
                        League = x.strLeague,
                        Stadium = x.strStadium
                    }).ToList();
                    result = resulTeamNames.Take(2).ToList();
                }
                return result;
            }
            catch 
            {
                throw new Exception("Error Team");
            }
        
        }

        public List<NameCountry> GetByCountries()
        {
            try
            {
                var httpResponse = client.GetAsync($"api/v1/json/1/all_countries.php").Result;
                httpResponse.EnsureSuccessStatusCode();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    return null;
                }

                List<NameCountry> resuList;

                using (HttpContent content = httpResponse.Content)
                {

                    string stringContent = content.ReadAsStringAsync()
                        .Result;

                    var resultService = JsonSerializer.Deserialize<NameCountryListSportDB>(stringContent);
                    resuList = resultService.countries.Select(x => new NameCountry() { name = x.name_en }).ToList();

                }

                return resuList;
            }
            catch
            {
                throw new Exception($"Error Country");
            }
        }


        public List<CountrySport> GetCountryBySports(string nameCountry)
        {
            try
            {
                var httpResponse = client.GetAsync($"api/v1/json/1/search_all_leagues.php?c={nameCountry}").Result;
                httpResponse.EnsureSuccessStatusCode();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    return null;
                }

                List<CountrySport> result;
                using (HttpContent content = httpResponse.Content)
                {

                    string stringContent = content.ReadAsStringAsync()
                        .Result;

                    var resultService = JsonSerializer.Deserialize<CountrySportDbList>(stringContent);
                    result = resultService.countrys.Select(x => new CountrySport()
                        {idLeague = x.idLeague, League = x.strLeague, Sport = x.strSport}).ToList();
                }

                return result;


            }
            catch
            {
                throw new Exception("Error League");
                
            }
        }



    }
}
