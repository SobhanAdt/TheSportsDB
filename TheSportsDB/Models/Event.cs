using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSportsDB.Models
{
    public class Event
    {
        public string idEvent { get; set; }

        public string EventName { get; set; }

        public string League { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public DateTime Timestamp { get; set; }
    }

    public class EventSportDB
    {
        public string idEvent { get; set; }

        public string strEvent { get; set; }

        public string strLeague { get; set; }

        public string strHomeTeam { get; set; }

        public string strAwayTeam { get; set; }

        public DateTime strTimestamp { get; set; }
    }

    public class EventSportList
    {
        public List<EventSportDB> events { get; set; }
    }

    public class EventSportListNetId
    {
        public List<EventSportDB> results { get; set; }
    }
}
