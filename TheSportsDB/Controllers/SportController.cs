using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSportsDB.HttpClinet;
using TheSportsDB.Models;
using TheSportsDB.Models;
using TheSportsDB.Models;

namespace TheSportsDB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly HttpClinetSport client;
        public SportController(HttpClinetSport client)
        {
            this.client = client;
        }
        [HttpGet]
        public List<SportName> NameSport()
        {
            return client.GetSportName();
        }

        [HttpGet]
        public List<TeamName> FavoritesTeam([FromQuery] string username)
        {
            return client.GetFavoritesTeam(username);
        }

        [HttpGet]
        public List<TeamName> DetaliTeam([FromQuery] string teamName)
        {
            return client.GetTeamByName(teamName);
        }

        [HttpGet]
        public List<NameCountry> Get()
        {
            return client.GetByCountries();
        }

        [HttpGet]
        public List<CountrySport> CountryBySports([FromQuery] string nameCountry)
        {
            return client.GetCountryBySports(nameCountry);
        }

        [HttpGet]
        public List<Country> Leagues([FromQuery] string c, string s)
        {
            return client.GetLeagues(c, s);
        }

        [HttpGet]
        public List<TeamsOfLeagueName> TeamsOfLeague([FromQuery] string LeagueName)
        {
            return client.GetLeaguestr(LeagueName);
        }
    }
}
