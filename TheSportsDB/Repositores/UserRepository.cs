using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSportsDB.Models;
using TheSportsDB.Services;

namespace TheSportsDB.Repositores
{
    public class UserRepository:IUserRepository
    {
        private static List<User> Users = new List<User>();
        private static int CurrentId = 1;

        public List<User> GetAllUser()
        {
            return Users;
        }

        public User GetByInfoUser(string username)
        {
            try
            {
                return Users.FirstOrDefault(x => x.UserName == username);
            }
            catch
            {
                Console.WriteLine($"hamchin user name vojo nadarad");
                throw;
            }
        }

        public void Insert(User user)
        {
            try
            {
                if (!Users.Any(x => x.Email == user.Email))
                {
                    if (!Users.Any(x => x.UserName == user.UserName))
                    {
                        user.UserId = CurrentId++;
                        Users.Add(user);
                    }
                }
            }
            catch
            {
                Console.WriteLine($"in {user.Email} ghblan sabt shode ast");
            }
        }
    }
}
