using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheSportsDB.HttpClinet;
using TheSportsDB.Models;

namespace TheSportsDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly HttpClinetSport client;
        public EventsController(HttpClinetSport client)
        {
            this.client = client;
        }
        [HttpGet]
        public List<Event> GetEvent([FromQuery] Event input)
        {
            switch (input.strSport)
            {
                case "Soccor":
                    return client.GetEvent(input.selected);
                case "meal":
                    return clientFood.GetFoodBycat(filter.cat);
                case "area":
                    return clientFood.GetFoodByarea(filter.area);

                default:
                    {
                        throw new ArgumentException("Invalid Category");
                    }
            }
            return null;
        }
    }
}
