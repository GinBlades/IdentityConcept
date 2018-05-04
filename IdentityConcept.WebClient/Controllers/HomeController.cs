using Microsoft.AspNetCore.Mvc;

namespace IdentityConcept.IdentityServer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
