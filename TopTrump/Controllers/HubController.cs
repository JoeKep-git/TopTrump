using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TopTrump.Controllers
{
    public class HubController : Controller
    {
        [Authorize]
        public IActionResult Index()
        { 
            return View(); 
        }
    }
}
