using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSportsDB.Models
{

    public class SportName
    {
        public string Sport { get; set; }
    }

    public class SportNameDB
    {
        public string strSport { get; set; }
    }


    public class SportNameLst
    {
        public List<SportNameDB> sports { get; set; }
    }

 

}
