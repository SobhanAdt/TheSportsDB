using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSportsDB.HttpClinet.Ali;
using TheSportsDB.Models.Ali;

namespace TheSportsDB.Controllers.Ali
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsOfLeagueController : ControllerBase
    {
            private readonly HttpClientTeamsOfLeague clientTeams;
            public TeamsOfLeagueController(HttpClientTeamsOfLeague clientTeams)
            {
                this.clientTeams = clientTeams;
            }
        [HttpGet]
        public List<TeamsOfLeagueName> GetTeamsOfLeague([FromQuery] string LeagueName)
        {
            return clientTeams.GetLeaguestr(LeagueName);
        }
    }
}
