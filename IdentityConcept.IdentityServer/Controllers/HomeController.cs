using IdentityConcept.IdentityServer.Models;
using IdentityConcept.IdentityServer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace IdentityConcept.IdentityServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMongoDatabase _db;

        public HomeController()
        {
            var client = new MongoClient("mongodb://192.168.1.130");
            _db = client.GetDatabase("IdentityConcept");
        }

        public async Task<IActionResult> Index()
        {
            var collection = _db.GetCollection<User>("Users");
            var users = await collection.Find(x => true)
                .SortBy(u => u.Email)
                .ToListAsync();

            var loginCollection = _db.GetCollection<Login>("Logins");
            var logins = await loginCollection.Find(x => true)
                .SortBy(l => l.LoginTime)
                .Limit(20)
                .ToListAsync();

            return View(new HomeVM
            {
                Logins = logins,
                Users = users
            });
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(User user)
        {
            var collection = _db.GetCollection<Login>("Logins");
            var login = new Login
            {
                Email = user.Email,
                LoginTime = DateTime.Now
            };
            await collection.InsertOneAsync(login);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            var collection = _db.GetCollection<User>("Users");
            await collection.InsertOneAsync(user);

            return RedirectToAction("Index");
        }
    }
}
