using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityConcept.IdentityServer.Models
{
    public class Login
    {
        public ObjectId Id { get; set; }
        public string Email { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
