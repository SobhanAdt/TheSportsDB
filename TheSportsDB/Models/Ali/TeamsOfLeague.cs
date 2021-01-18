using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSportsDB.Models.Ali
{
    public class TeamsOfLeague
    {
        public string idLeague { get; set; }
        public string strTeam { get; set; }
        public string strLeague { get; set; }
    }
    public class TeamsOfLeagueList
    {
        public List<TeamsOfLeague> teams { get; set; }
    }
}
