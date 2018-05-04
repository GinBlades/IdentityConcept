using IdentityConcept.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityConcept.IdentityServer.ViewModels
{
    public class HomeVM
    {
        public List<User> Users { get; set; }
        public List<Login> Logins { get; set; }
    }
}
