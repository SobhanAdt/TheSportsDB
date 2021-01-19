using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSportsDB.Models
{
    public class Country
    {
        public string Id { get; set; }
        public string Sport { get; set; }
        public string League { get; set; }
        public string country { get; set; }
      
    }

    public class CountrySportDB
    {
        public string idLeague { get; set; }
        public string strSport { get; set; }
        public string strLeague { get; set; }
        public string strCountry { get; set; }

    }
    public class Countrylst
    {
        public List<CountrySportDB> countrys { get; set; }
    }
 

}
