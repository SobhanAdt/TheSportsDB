using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSportsDB.Models;
using TheSportsDB.Services;

namespace TheSportsDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public string Create([FromBody] User user)
        {
            repository.Insert(user);
            return user.Email;
        }

        [HttpGet]
        public List<User> Get()
        {
            return repository.GetAllUser();
        }
    }
}
