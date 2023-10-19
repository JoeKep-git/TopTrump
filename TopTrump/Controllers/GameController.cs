using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopTrump.Data;
using TopTrump.Models;


namespace TopTrump.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Deck selectedDeck;
        private Player player;
        private Bot bot;
        private string selectedStat;
        private string difficulty;

        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var availableDecks = _context.Decks.ToList();
            var availableDifficultyOptions = new List<string> { "Easy", "Medium", "Hard" };

            var viewModel = new ChooseGameViewModel
            {
                AvailableDecks = availableDecks,
                DifficultyOptions = availableDifficultyOptions
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult StartGame(int selectedDeckId, string selectedDifficulty)
        {
            selectedDeck = _context.Decks
                .Include(d => d.Cards)
                .FirstOrDefault(d => d.DeckId == selectedDeckId);

            if (selectedDeck != null)
            {
                player = new Player("Player");
                bot = new Bot("Bot");

                // Initialize their hands
                player.UserHand = new List<Card>();
                bot.BotHand = new List<Card>();

                // Distribute cards to the hands
                DistributeCards();

                // Set other properties like selectedStat and difficulty
                difficulty = selectedDifficulty;
                selectedStat = "Stat1"; // Set a default stat or implement logic to select a stat

                return RedirectToAction("SelectStat", new { selectedDeckId });
            }

            return RedirectToAction("Index");
        }

        public IActionResult SelectStat(int selectedDeckId)
        {
            var selectedDeck = _context.Decks
                .Include(d => d.Cards)
                .FirstOrDefault(d => d.DeckId == selectedDeckId);

            if (selectedDeck != null)
            {
                var viewModel = new SelectStatViewModel
                {
                    Cards = selectedDeck.Cards.ToList(),
                    StatNames = new List<string>
                    {
                        selectedDeck.Stat1,
                        selectedDeck.Stat2,
                        selectedDeck.Stat3,
                        selectedDeck.Stat4
                    }
                };

                return View(viewModel);
            }
            else
            {
                // Handle the case where the selected deck is not found
                return RedirectToAction("Index");
            }
        }

        private void DistributeCards()
        {
            if (selectedDeck != null)
            {
                Console.WriteLine(selectedDeck);

                // Ensure that player and bot objects are not null before accessing UserHand and BotHand
                if (player != null && bot != null)
                {
                    Random random = new Random();

                    player.UserHand = new List<Card>(); // Initialize the user's hand
                    bot.BotHand = new List<Card>();    // Initialize the bot's hand

                    for (int i = 0; i < selectedDeck.Cards.Count / 2; i++)
                    {
                        int randomIndex = random.Next(selectedDeck.Cards.Count);
                        player.UserHand.Add(selectedDeck.Cards[randomIndex]);
                        selectedDeck.Cards.RemoveAt(randomIndex);

                        randomIndex = random.Next(selectedDeck.Cards.Count);
                        bot.BotHand.Add(selectedDeck.Cards[randomIndex]);
                        selectedDeck.Cards.RemoveAt(randomIndex);
                    }
                }
            }
        }

        [HttpPost]
        public IActionResult SelectStat(string stat)
        {
            selectedStat = stat;

            return RedirectToAction("PlayRound");
        }

        public IActionResult PlayRound()
        {
            Card playerCard = player.PlayCard();
            Card botCard = bot.PlayCard(selectedStat, difficulty);

            string winner = DetermineWinner(playerCard, botCard);

            if (winner == "Player")
            {
                player.Win(new List<Card> { botCard });
            }
            else if (winner == "Bot")
            {
                bot.Win(new List<Card> { playerCard });
            }

            if (player.UserHand.Count == 0 || bot.BotHand.Count == 0)
            {
                return RedirectToAction("GameOver", new { Winner = winner });
            }

            var viewModel = new PlayRoundViewModel
            {
                UserCard = playerCard,
                BotCard = botCard,
                Winner = winner
            };

            return View(viewModel);
        }

        private string DetermineWinner(Card playerCard, Card botCard)
        {
            // Implement your logic to determine the winner based on selectedStat
            // For example, compare the card values
            return "Player"; // Replace with your logic
        }

        public IActionResult GameOver(string Winner)
        {
            ViewBag.Winner = Winner;
            return View();
        }
    }
}
