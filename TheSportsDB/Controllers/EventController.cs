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
    public class EventController : ControllerBase
    {
        private readonly HttpClinetSport clinet;

        public EventController(HttpClinetSport clinet)
        {
            this.clinet = clinet;
        }

        [HttpGet]
        public List<Event> NextPlay(string id)
        {
            return clinet.GetNext15EventsbyLeague(id);
        }

        [HttpGet]
        public List<Event> LastPlay(string id)
        {
            return clinet.GetLast15EventsbyLeague(id);
        }

        [HttpGet]
        public List<Event> LastFiveGame(string id)
        {
            return clinet.GetLast5EventsbyTeam(id);
        }
    }
}
