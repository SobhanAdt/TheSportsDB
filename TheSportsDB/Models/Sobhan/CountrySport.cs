using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSportsDB.Models.Sobhan
{
    public class CountrySport
    {
        public string idLeague { get; set; }
        public string Sport { get; set; }

        public string League { get; set; }
    }

    //public class CountrySportList
    //{
    //    public List<CountrySport> CountrySports { get; set; }
    //}

    public class CountrySportDb
    {
        public string idLeague { get; set; }
        public string strSport { get; set; }

        public string strLeague { get; set; }
    }

    public class CountrySportDbList
    {
        public List<CountrySportDb> countrys { get; set; }
    }


}
