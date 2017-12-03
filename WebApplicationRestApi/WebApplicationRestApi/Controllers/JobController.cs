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


        //List<string> myCollection = new List<string>() { "Massachusetts", "California" };

        //private static string[] JobLocation = new[]
        //{
        //    "Massachusetts", "California", "Atlanta", "Gearogia", "NewYork", "Florida", "Chicago", "Texas", "Georgia", "Utah"
        //};


        [HttpGet("[action]")]
        public IEnumerable<Job> GetAllJobs()
        {

            //string[] JobLocations = new[]
            //{
            //    "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming"
            //};

            //var list = new List<Job>();
            //list.Add(new Job() { Name = "Lilly" });
            //list.Add(new Job() { Name = "Lucy" });
            //return list;

            string connectionString = "mongodb://kshettar:Skiran*3@ds249325.mlab.com:49325/users";
            var mongoClient = new MongoClient(connectionString);
            var db = mongoClient.GetDatabase("users");
            var collection = db.GetCollection<BsonDocument>("location");
            var docs = collection.Find(new BsonDocument()).ToListAsync().GetAwaiter().GetResult();
            List<string> myCollection = new List<string>();
            foreach (BsonDocument l in docs)
            {
                var documnt = new BsonDocument(l);

                string id = documnt[0].ToString();
                string StateName = documnt[1].ToString();
                myCollection.Add(StateName);
                //Console.WriteLine(StateName + "\n");
            }

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Job
            {
                Name = Summaries[rng.Next(Summaries.Length)],
                //Location = JobLocation[rng.Next(JobLocation.Length)]
                Location = myCollection[rng.Next(myCollection.Count)]
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