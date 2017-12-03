using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationRestApi.Model;

//MongoDB
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using Microsoft.Extensions.Configuration.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationRestApi.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class JobApplyController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<JobApply> GetAllJobs()
        {
            string connectionString = "mongodb://kshettar:Skiran*3@ds249325.mlab.com:49325/users";
            var mongoClient = new MongoClient(connectionString);
            var db = mongoClient.GetDatabase("users");
            var collection = db.GetCollection<BsonDocument>("jobdata");
            var docs = collection.Find(new BsonDocument()).ToListAsync().GetAwaiter().GetResult();
            List<string> myCollection = new List<string>();
            foreach (BsonDocument l in docs)
            {
                var documnt = new BsonDocument(l);

                string id = documnt[0].ToString();
                string JobName = documnt[1].ToString();
                string JobCompany = documnt[2].ToString();
                string JobSkills = documnt[3].ToString();
                string JobLocation = documnt[4].ToString();
                string JobEmail = documnt[5].ToString();

                myCollection.Add(JobName);
                myCollection.Add(JobCompany);
                myCollection.Add(JobSkills);
                myCollection.Add(JobLocation);
                myCollection.Add(JobEmail);
                //Console.WriteLine(StateName + "\n");
            }

            var rng = new Random();
            int count = 0;

            return Enumerable.Range(1, 10).Select(index => new JobApply
            {
                Jobname = myCollection[count++],
                Jobskills = myCollection[count++],
                Jobcompany = myCollection[count++],
                Joblocation = myCollection[count++],
                Jobemail = myCollection[count++]
                //Location = JobLocation[rng.Next(JobLocation.Length)]
                //Location = myCollection[rng.Next(myCollection.Count)]
            });

            //var rng = new Random();

            //return Enumerable.Range(1, 10).Select(index => new JobApply
            //{
            //    Name = myCollection[rng.Next(myCollection.Count)]
            //    //Location = JobLocation[rng.Next(JobLocation.Length)]
            //    //Location = myCollection[rng.Next(myCollection.Count)]
            //});
        }
    }
}