using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TopTrump.Controllers
{
    public class LobbyPage : Controller
    {
        [Authorize]
        public IActionResult Index(string name)
        {
            ViewData["LobbyName"] = name;
            return View();
        }
    }
}
