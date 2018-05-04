using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityConcept.IdentityServer.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        [BsonIgnoreIfDefault]
        public string FirstName { get; set; }
        [BsonIgnoreIfDefault]
        public string LastName { get; set; }
        [BsonIgnoreIfDefault]
        public string UserName { get; set; }
        [BsonIgnoreIfDefault]
        public string Email { get; set; }
        [BsonIgnoreIfDefault]
        public string Password { get; set; }
    }
}
