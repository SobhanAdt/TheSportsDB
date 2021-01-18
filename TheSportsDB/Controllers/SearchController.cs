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
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly HttpClinetSport clinet;

        public SearchController(HttpClinetSport clinet)
        {
            this.clinet = clinet;
        }

        [HttpGet]
        public List<TeamName> GetByName([FromQuery]string teamName)
        {
            return clinet.GetTeamByName(teamName);
        }
    }
}
