using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSportsDB.HttpClinet;
using TheSportsDB.Models.Sobhan;

namespace TheSportsDB.Controllers.Sobhan
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountrySportController : ControllerBase
    {
        private readonly HttpClinetSport clinet;

        public CountrySportController(HttpClinetSport clinet)
        {
            this.clinet = clinet;
        }

        [HttpGet]
        public List<CountrySport> GetCountryBySports([FromQuery] string nameCountry)
        {
            return clinet.GetCountryBySports(nameCountry);
        }
    }
}
