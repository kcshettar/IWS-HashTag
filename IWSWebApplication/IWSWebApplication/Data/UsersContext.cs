using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using IWSWebApplication.Models;

namespace IWSWebApplication.Data
{
    public class UsersContext
    {
        private readonly IMongoDatabase _database = null;

        public UsersContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<Users> Users
        {
            get
            {
                return _database.GetCollection<Users>("Users");
            }
        }
    }
}


