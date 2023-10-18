using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using TopTrump.Models;

namespace TopTrump.Controllers
{
    public class GameController : Controller
    {
        // Define global variables to hold game state
        private Deck selectedDeck;
        private Player player;
        private Bot bot;
        private string selectedStat;
        private Card selectedCard;
        private string difficulty;

        public IActionResult Index()
        {
            // Initialize game state
            player = new Player("Player");
            bot = new Bot("Bot");

            // Distribute cards
            DistributeCards();

            // Redirect to the page for selecting a stat
            return RedirectToAction("SelectStat");
        }

        // Method to distribute cards to player and bot
        private void DistributeCards()
        {
            Random random = new Random();
            for (int i = 0; i < selectedDeck.Cards.Count / 2; i++)
            {
                int randomIndex = random.Next(selectedDeck.Cards.Count);
                player.Hand.Add(selectedDeck.Cards[randomIndex]);
                selectedDeck.Cards.RemoveAt(randomIndex);

                randomIndex = random.Next(selectedDeck.Cards.Count);
                bot.Hand.Add(selectedDeck.Cards[randomIndex]);
                selectedDeck.Cards.RemoveAt(randomIndex);
            }
        }

        public IActionResult SelectStat()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SelectStat(string stat)
        {
            selectedStat = stat;

            // Redirect to the page for playing a round
            return RedirectToAction("PlayRound");
        }

        public IActionResult PlayRound()
        {
            // Logic for playing a round
            Card playerCard = player.PlayCard(selectedCard);
            Card botCard = bot.PlayCard(selectedStat, difficulty);

            // Determine the winner
            string winner = DetermineWinner(playerCard, botCard);

            // Handle winner
            if (winner == "Player")
            {
                player.Hand.Add(botCard);
            }
            else if (winner == "Bot")
            {
                bot.Hand.Add(playerCard);
            }

            // Check if game is over
            if (player.Hand.Count == 0 || bot.Hand.Count == 0)
            {
                // Game over, redirect to game over page
                return RedirectToAction("GameOver", new { Winner = winner });
            }

            // Continue to the next round (redirect to PlayRound)
            return RedirectToAction("PlayRound");
        }

        // Method to determine the winner based on selected stat
        private string DetermineWinner(Card playerCard, Card botCard)
        {
            PropertyInfo statProperty = typeof(Card).GetProperty(selectedStat);

            if (statProperty != null && statProperty.PropertyType == typeof(int))
            {
                int playerStatValue = (int)statProperty.GetValue(playerCard);
                int botStatValue = (int)statProperty.GetValue(botCard);

                if (playerStatValue > botStatValue)
                {
                    return "Player";
                }
                else if (botStatValue > playerStatValue)
                {
                    return "Bot";
                }
                else
                {
                    return "Draw";
                }
            }
            //By default player wins
            return "Player";
        }

        public IActionResult GameOver(string Winner)
        {
            ViewBag.Winner = Winner;
            return View();
        }
    }

}
