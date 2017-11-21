using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

//MongoDB
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using Json;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationIWS.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        public class JwtPacket
        {
            public string Token { get; set; }
            public string FirstName { get; set; }
        }

        [HttpPost("register")]
        public JwtPacket Register([FromBody]Models.User user)
        {
            var jwt = new JwtSecurityToken();
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            
            /* Database Connection
             * Insert Values in Database userdata 
             */
            string connectionString = "mongodb://kshettar:*******3@ds249325.mlab.com:49325/users";
            var mongoClient = new MongoClient(connectionString);
            var db = mongoClient.GetDatabase("users");
            var collection = db.GetCollection<BsonDocument>("userdata");
            var document = new BsonDocument
            {
                {"First Name", user.firstName},
                {"Last Name", user.lastName},
                {"E-Mail", user.eMail},
                {"Password", user.userPassword }
            };
            collection.InsertOneAsync(document);

            return new JwtPacket()
            {
                Token = encodedJwt
                ,FirstName = user.firstName
            };
        }

        //// GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
