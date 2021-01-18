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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly HttpClinetSport clinet;

        public CountryController(HttpClinetSport clinet)
        {
            this.clinet = clinet;
        }

        [HttpGet]
        public List<NameCountry> Get()
        {
            return clinet.GetByCountries();
        }

        [HttpGet]
        public List<CountrySport> GetCountryBySports([FromQuery] string nameCountry)
        {
            return clinet.GetCountryBySports(nameCountry);
        }
    }
}
