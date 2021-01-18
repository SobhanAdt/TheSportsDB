using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheSportsDB.HttpClinet;
using TheSportsDB.Models;

namespace TheSportsDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sportsController : ControllerBase
    {
        private readonly HttpClinetSport client;
        public sportsController(HttpClinetSport client)
        {
            this.client = client;
        }
        [HttpGet]
        public List<SportName> Getarea()
        {
            return client.GetSportName();
        }
    }
}
