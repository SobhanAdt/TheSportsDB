using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSportsDB.Models.Sobhan
{
    public class NameCountry
    {
        public string name { get; set; }
    }

    public class NameCountrySportDB
    {
        public string name_en { get; set; }
    }

    public class NameCountryListSportDB
    {
        public List<NameCountrySportDB> countries { get; set; }
    }

}
