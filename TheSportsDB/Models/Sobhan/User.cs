using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheSportsDB.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "format email vard shode sahih nist gole mn")]
        public string Email { get; set; }

        public List<string> favorites { get; set; }
    }
}
