using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IWSWebApplication.Controllers
{
    public class JwtPacket
    {
        public string Token { get; set; }
        public string firstName { get; set; }
    }

    [Produces("application/json")]
    [Route("auth")]
    public class AuthController : Controller 
    {
        readonly ApiContext context;

        public AuthController(ApiContext context)
        {
            this.context = context;
        }

        [HttpPost("register")]
        public JwtPacket Register([FromBody]Models.User user)
        {
            var jwt = new JwtSecurityToken();
            var encodedJwt = new JwtSecurityTokenHandler()
                .WriteToken(jwt);

            context.Users.Add(user);
            context.SaveChanges();

            return new JwtPacket() { Token = encodedJwt, firstName = user.firstName };
        }
    }
}