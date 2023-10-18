using Microsoft.AspNetCore.Mvc;
using TopTrump.Models;

namespace TopTrump.Controllers
{
    public class GameController : Controller
    {
        //Defining global variables
        private Deck selectedDeck;


        public IActionResult Index()
        {
            return View();
        }
    }
}
