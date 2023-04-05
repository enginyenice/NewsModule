using NewsModule.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsModule.Entities.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<Role>? Roles { get; set; }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

    }
}
