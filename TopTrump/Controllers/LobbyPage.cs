using Microsoft.AspNetCore.Mvc;

namespace TopTrump.Controllers
{
    public class LobbyPage : Controller
    {
        public IActionResult Index(string name)
        {
            ViewData["LobbyName"] = name;
            return View();
        }
    }
}
