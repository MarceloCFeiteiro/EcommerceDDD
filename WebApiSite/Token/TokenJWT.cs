using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSite.Token
{
    public class TokenJWT
    {
        private JwtSecurityToken token;

        public DateTime ValidTo => token.ValidTo;

        public string Value => new JwtSecurityTokenHandler().WriteToken(this.token);

        internal TokenJWT(JwtSecurityToken token)
        {
            this.token = token;
        }
    }
}