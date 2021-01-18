using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSportsDB.Models;

namespace TheSportsDB.Services
{
    public interface IUserRepository
    {
        void Insert(User register);

        User GetByInfoUser(string username);

        List<User> GetAllUser();
    }
}
