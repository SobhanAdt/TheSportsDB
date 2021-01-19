using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSportsDB.Models
{
    public class TeamsOfLeague
    {
        public string idLeague { get; set; }
        public string strTeam { get; set; }
        public string strLeague { get; set; }
    }

    public class TeamsOfLeagueName
    {
        public string Id { get; set; }
        public string TeamName { get; set; }
        public string LeagueName { get; set; }
    }

    public class TeamsOfLeagueList
    {
        public List<TeamsOfLeague> teams { get; set; }
    }
}
