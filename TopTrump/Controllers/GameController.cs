using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TopTrump.Data;
using TopTrump.Models;


namespace TopTrump.Controllers
{
    // GameController.cs
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ChooseGame()
        {
            var availableDecks = _context.Decks.ToList();
            var viewModel = new ChooseGameViewModel
            {
                AvailableDecks = availableDecks
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult StartGame(string difficulty, int deck)
        {
            // Implement game logic based on the selected difficulty and deck
            // Create a game session and start the game

            return RedirectToAction("Gameplay"); // Redirect to the gameplay view
        }

        public IActionResult Gameplay()
        {
            // Implement the gameplay logic here
            // Display the game interface and handle user interactions

            return View();
        }
    }

}