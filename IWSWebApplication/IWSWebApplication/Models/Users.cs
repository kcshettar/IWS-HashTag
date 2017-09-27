using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace IWSWebApplication.Models
{
    public class Users
    {
        [BsonId]
        public string Id { get; set; }
        public int User_id { get; set; } = 0;
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Array Skills { get; set; }
    }
}
