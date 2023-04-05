using NewsModule.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsModule.Entities.Models
{
    public class Role : BaseEntity
    {
        public Role(string roleName)
        {
            RoleName = roleName;
        }

        public string RoleName { get; set; }
        public virtual List<User>? Users { get; set; }
    }
}
