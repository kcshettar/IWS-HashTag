using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IWSWebApplication.Models
{
    public class Users
    {
        [BsonId]
        public string Id { get; set; }
        [BsonRequired]
        public string FirstName { get; set; }
        [BsonRequired]
        public string LastName { get; set; }
        [BsonRequired]
        public string ZipCode { get; set; }
        [BsonRequired]
        public string Email { get; set; }
        [BsonRequired]
        public string Username { get; set; }
        [BsonRequired]
        public string Password { get; set; }
    }
}
