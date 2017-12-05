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
        [HttpGet("[action]")]
        public IEnumerable<Job> GetAllJobs()
        {
            string connectionString = "mongodb://kshettar:Skiran*3@ds249325.mlab.com:49325/users";
            var mongoClient = new MongoClient(connectionString);
            var db = mongoClient.GetDatabase("users");
            var collectionName = db.GetCollection<BsonDocument>("companyname");
            var collectionRole = db.GetCollection<BsonDocument>("jobroles");
            var collectionLocation = db.GetCollection<BsonDocument>("location");
            var collectionDate = db.GetCollection<BsonDocument>("dateExpired");
            
            var docsName = collectionName.Find(new BsonDocument()).ToListAsync().GetAwaiter().GetResult();
            var docsRole = collectionRole.Find(new BsonDocument()).ToListAsync().GetAwaiter().GetResult();
            var docsLocation = collectionLocation.Find(new BsonDocument()).ToListAsync().GetAwaiter().GetResult();
            var docsDate = collectionDate.Find(new BsonDocument()).ToListAsync().GetAwaiter().GetResult();

            List<string> myCollectionName = new List<string>();
            List<string> myCollectionRole = new List<string>();
            List<string> myCollectionLocation = new List<string>();
            List<string> myCollectionDate = new List<string>();

            foreach (BsonDocument l in docsName)
            {
                var documnt = new BsonDocument(l);

                string id = documnt[0].ToString();
                string CompanyName = documnt[1].ToString();
                myCollectionName.Add(CompanyName);
            }

            foreach (BsonDocument l in docsRole)
            {
                var documnt = new BsonDocument(l);

                string id = documnt[0].ToString();
                string JobRole = documnt[1].ToString();
                myCollectionRole.Add(JobRole);
            }

            foreach (BsonDocument l in docsLocation)
            {
                var documnt = new BsonDocument(l);

                string id = documnt[0].ToString();
                string JobLocation = documnt[1].ToString();
                myCollectionLocation.Add(JobLocation);
            }

            foreach (BsonDocument l in docsDate)
            {
                var documnt = new BsonDocument(l);

                string id = documnt[0].ToString();
                string JobDate = documnt[1].ToString();
                myCollectionDate.Add(JobDate);
            }

            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new Job
            {
                Companyname = myCollectionName[rng.Next(myCollectionName.Count)],
                Jobrole = myCollectionRole[rng.Next(myCollectionRole.Count)],
                Joblocation = myCollectionLocation[rng.Next(myCollectionLocation.Count)],
                Jobdate = myCollectionDate[rng.Next(myCollectionDate.Count)],
            });
        }
    }
}