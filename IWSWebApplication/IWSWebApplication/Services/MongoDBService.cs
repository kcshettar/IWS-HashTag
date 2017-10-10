using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IWSWebApplication.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace IWSWebApplication.Services
{
    public class MongoDBService
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        private IMongoDatabase _database { get; }

        public MongoDBService()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                var client = new MongoClient(settings);
                _database = client.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Can not connect to DB: ", ex);
            }
        }

        public IMongoCollection<Users> User
        {
            get
            {
                return _database.GetCollection<Users>("Users");
            }
        }
    }

    /*
    public class MongoDBService
    {
        private readonly IMongoDatabase _database = null;

        public MongoDBService(IOptions<Settings> settings)
        {
            try
            {
                var client = new MongoClient(settings.Value.ConnectionString);
                if (client != null)
                {
                    _database = client.GetDatabase(settings.Value.Database);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Can not Access DB Server: ", ex);
            }

        }

        public IMongoCollection<Users> User
        {
            get
            {
                return _database.GetCollection<Users>("Users");
            }
        }
    }*/
}
