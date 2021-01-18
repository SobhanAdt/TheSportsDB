using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheSportsDB.HttpClinet.Rahbar;
using TheSportsDB.Models.Rahbar;

namespace TheSportsDB.Controllers.Rahbar
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllLeaguesController : ControllerBase
    {
        private readonly HttpClientLeague client;
        public AllLeaguesController(HttpClientLeague client)
        {
            this.client = client;
        }
        [HttpGet]
        public List<League> GetName([FromQuery] string c,string s)
        {
            return client.GetLeagues(c,s);
        }
    }
}
