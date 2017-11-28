using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.Core;
using Json;
using Newtonsoft.Json;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.IO;

namespace ConsoleAppMlab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CallMain(args).Wait();
        }

        static async Task CallMain(string[] args)
        {
            string connectionString = "mongodb://kshettar:Skiran*3@ds249325.mlab.com:49325/users";
            var mongoClient = new MongoClient(connectionString);
            var db = mongoClient.GetDatabase("users");
            //string output = mongo.Client.WithReadConcern ;
            //Console.WriteLine(output);
            var collection = db.GetCollection<BsonDocument>("userdata");
            //var collection = db.GetCollection<BsonDocument>("userdata");

            //var documnt = new BsonDocument
            //{
            //    {"First Name","SSS"},
            //    {"Last Name","KKK"},
            //    {"State","USA"}
            //};
            //collection.InsertOneAsync(documnt);



            Console.WriteLine("Press Enter to insert the data");
            Console.ReadLine();



            //var collection = db.GetCollection<BsonDocument>("userdata");
            //await collection.Find(new BsonDocument()).ForEachAsync(X => Console.WriteLine(X));

            var docs = collection.Find(new BsonDocument()).ToListAsync().GetAwaiter().GetResult();

            var filter2 = Builders<BsonDocument>.Filter.Eq("First Name", "KCS");
            var result = await collection.Find(filter2).ToListAsync();

            foreach(BsonDocument l in docs)
            {
                var documnt = new BsonDocument(l);

                string id = documnt[0].ToString();
                string FirstName = documnt[1].ToString();
                string LastName = documnt[2].ToString();
                string Email = documnt[3].ToString();
                Console.WriteLine(FirstName + "|" + LastName + "|" + Email + "\n");
                
            }

            Console.WriteLine("Hello");
            
        }
    }
}
