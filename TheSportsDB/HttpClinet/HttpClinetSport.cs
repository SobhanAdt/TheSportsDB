using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using TheSportsDB.Models;
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

        //Sobhan
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
                    result = resulTeamNames.Take(1).ToList();
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

        public List<Event> GetNext15EventsbyLeague(string id)
        {
            try
            {
                var httpResponse = client.GetAsync($"api/v1/json/1/eventsnextleague.php?id={id}").Result;
                httpResponse.EnsureSuccessStatusCode();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    return null;
                }

                List<Event> events;
                using (HttpContent content = httpResponse.Content)
                {

                    string stringContent = content.ReadAsStringAsync()
                        .Result;

                    var eventService = JsonSerializer.Deserialize<EventSportList>(stringContent);
                    events = eventService.events.Select(x => new Event()
                    {
                        idEvent = x.idEvent, EventName = x.strEvent, AwayTeam = x.strAwayTeam, HomeTeam = x.strHomeTeam,
                        League = x.strLeague, Timestamp = x.strTimestamp
                    }).ToList();
                }

                return events;
            }
            catch
            {
                throw new Exception("Error Message Event Nest");
            }
        }

        public List<Event> GetLast15EventsbyLeague(string id)

        {
            try
            {
                var httpResponse = client.GetAsync($"api/v1/json/1/eventspastleague.php?id={id}").Result;
                httpResponse.EnsureSuccessStatusCode();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    return null;
                }

                List<Event> events;
                using (HttpContent content = httpResponse.Content)
                {

                    string stringContent = content.ReadAsStringAsync()
                        .Result;

                    var eventService = JsonSerializer.Deserialize<EventSportList>(stringContent);
                    events = eventService.events.Select(x => new Event()
                    {
                        idEvent = x.idEvent,
                        EventName = x.strEvent,
                        AwayTeam = x.strAwayTeam,
                        HomeTeam = x.strHomeTeam,
                        League = x.strLeague,
                        Timestamp = x.strTimestamp
                    }).ToList();
                }

                return events;
            }
            catch
            {
                throw new Exception("Error Message Event Nest");
            }
        }

        public List<Event> GetLast5EventsbyTeam(string id)

        {
            try
            {
                var httpResponse = client.GetAsync($"api/v1/json/1/eventslast.php?id={id}").Result;
                httpResponse.EnsureSuccessStatusCode();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    return null;
                }

                List<Event> events;
                using (HttpContent content = httpResponse.Content)
                {

                    string stringContent = content.ReadAsStringAsync()
                        .Result;

                    var eventService = JsonSerializer.Deserialize<EventSportList>(stringContent);
                    events = eventService.events.Select(x => new Event()
                    {
                        idEvent = x.idEvent,
                        EventName = x.strEvent,
                        AwayTeam = x.strAwayTeam,
                        HomeTeam = x.strHomeTeam,
                        League = x.strLeague,
                        Timestamp = x.strTimestamp
                    }).ToList();
                }

                return events;
            }
            catch
            {
                throw new Exception("Error Message Event Nest");
            }
        }

        public List<TeamName> GetFavoritesTeam(string username)
        {
            try
            {
                var Success = repository.GetByInfoUser(username);
                if (Success.UserName == null)
                    return null;

                List<TeamName> lstTeam = new List<TeamName>();
                for (int i = 0; i < Success.favorites.Count; i++)
                {
                    var result = GetTeamByName(Success.favorites[i]);
                    lstTeam.AddRange(result);
                }

                return lstTeam;
            }
            catch
            {
                throw new Exception("Error Favorites Team");
            }
          
        }


        //Mr Ali
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
            catch (Exception)
            {
                throw new Exception("Invalid Input");
            }
        }


        //Miss Rahbar
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
                    result = resultService.sports.Select(x => new SportName { Sport = x.strSport }).ToList();
                }
                return result;
            }
            catch (Exception)
            {

                throw new Exception("your request has problem!");
            }
        }

        public List<Country> GetLeagues(string c, string s)
        {

            var httpResponse = client.GetAsync($"api/v1/json/1/search_all_leagues.php?c={c}&s={s}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }
            List<Country> result;
            using (HttpContent content = httpResponse.Content)
            {

                string stringContent = content.ReadAsStringAsync()
                    .Result;

                var resultService = JsonSerializer.Deserialize<Countrylst>(stringContent);
                result = resultService.countrys.Select(x => new Country
                {
                    League = x.strLeague,
                    country = x.strCountry,
                    Sport = x.strSport,
                    Id = x.idLeague
                }).ToList();
            }
            return result;

        }

    }
}
