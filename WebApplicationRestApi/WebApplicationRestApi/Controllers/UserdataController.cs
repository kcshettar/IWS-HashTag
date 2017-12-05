using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationRestApi.Model;

//MongoDB
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using Microsoft.Extensions.Configuration.Json;

namespace WebApplicationRestApi.Controllers
{
    [Produces("application/json")]
    [Route("userdata")]
    public class UserdataController : Controller
    {
        [HttpPost("form-submit")]
        public void Submitdata([FromBody]Model.User user)
        {
            string connectionString = "mongodb://kshettar:Skiran*3@ds249325.mlab.com:49325/users";
            var mongoClient = new MongoClient(connectionString);
            var db = mongoClient.GetDatabase("users");
            var collection = db.GetCollection<BsonDocument>("userformdata");

            var documnt = new BsonDocument
            {
                {"First Name", user.firstName},
                {"Last Name", user.lastName},
                {"Job ID", user.jobId},
                {"Email", user.eMail},
                {"Phone", user.phone}
            };
            collection.InsertOneAsync(documnt);
        }
    }
}