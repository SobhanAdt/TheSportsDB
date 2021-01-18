using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSportsDB.Models.Rahbar
{
    public class League
    {
        public string idLeague { get; set; }
        public string strSport { get; set; }
        public string strLeague { get; set; }
        public string strCountry { get; set; }
    }
    public class Leaguelst
    {
        public List<League> leagues { get; set; }
    }
}
