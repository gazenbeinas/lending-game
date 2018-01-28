using Microsoft.AspNetCore.Mvc;

namespace LendingGame.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}