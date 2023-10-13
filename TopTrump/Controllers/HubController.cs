using Microsoft.AspNetCore.Mvc;

namespace TopTrump.Controllers
{
    public class HubController : Controller
    {
        public IActionResult Index()
        { 
            return View(); 
        }
    }
}
