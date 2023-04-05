using NewsModule.DTOs.UserDtos;
using NewsModule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsModule.Business.Security
{
    public interface IJWTHelper
    {
        TokenDto CreateJwtToken(User user);
    }
}
