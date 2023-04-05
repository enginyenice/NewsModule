using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsModule.DTOs.UserDtos
{
    public class TokenDto
    {
        public TokenDto(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
