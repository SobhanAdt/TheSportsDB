using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSportsDB.Models
{
    public class TeamName
    {
        public string Team { get; set; }

        public string Alternate { get; set; }

        public string FormedYear { get; set; }

        public string League { get; set; }

        public string Stadium { get; set; }

        public string DescriptionEN { get; set; }
    }

    public class TeamNameTheSports
    {
        public string strTeam { get; set; }

        public string strAlternate { get; set; }

        public string intFormedYear { get; set; }

        public string strLeague { get; set; }

        public string strStadium { get; set; }

        public string strDescriptionEN { get; set; }
    }

    public class TeamList
    {
        public List<TeamNameTheSports> teams { get; set; }
    }

}
