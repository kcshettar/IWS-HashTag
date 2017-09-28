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
        [BsonElement]
        public string FirstName { get; set; }
        [BsonElement]
        public string LastName { get; set; }
        [BsonElement]
        public string ZipCode { get; set; }
        [BsonElement]
        public string Email { get; set; }
        [BsonElement]
        public string Username { get; set; }
        [BsonElement]
        public string Password { get; set; }
    }
}
