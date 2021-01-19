using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSportsDB.HttpClinet;
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
    }
}
