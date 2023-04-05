using NewsModule.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsModule.Entities.Models
{
    public class News : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

    }
}
