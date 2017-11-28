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
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class JobController : Controller
    {

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static string[] JobLocation = new[]
        {
            "Massachusetts", "California", "Atlanta", "Gearogia", "NewYork", "Florida", "Chicago", "Texas", "Georgia", "Utah"
        };


        [HttpGet("[action]")]
        public IEnumerable<Job> GetAllJobs()
        {
            //var list = new List<Job>();
            //list.Add(new Job() { Name = "Lilly" });
            //list.Add(new Job() { Name = "Lucy" });
            //return list;

            //string connectionString = "mongodb://kshettar:Skiran*3@ds249325.mlab.com:49325/users";
            //var mongoClient = new MongoClient(connectionString);
            //var db = mongoClient.GetDatabase("users");
            //var collection = db.GetCollection<BsonDocument>("userdata");

            //var document = new BsonDocument
            //{
            //    {"First Name", user.firstName},
            //    {"Last Name", user.lastName},
            //    {"E-Mail", user.eMail},
            //    {"Password", user.userPassword }
            //};
            //collection.InsertOneAsync(document);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Job
            {
                Name = Summaries[rng.Next(Summaries.Length)],
                Location = JobLocation[rng.Next(JobLocation.Length)]
            });
        }

        //[HttpGet("{name}")]
        //public Job Get(string name)
        //{
        //    return new Job() { Name = name };
        //}

        //[HttpPost]
        //public Job Insert([FromBody]Model.Job job)
        //{
        //    // write the new cat to database
        //    return job;
        //}

        //[HttpPut("{name}")]
        //public Job Update(string name, [FromBody]Job job)
        //{
        //    job.Name = name;
        //    // write the updated cat to database
        //    return job;
        //}

        //[HttpDelete("{name}")]
        //public void Delete(string name)
        //{
        //    // delete the cat from the database

        //}
    }
}