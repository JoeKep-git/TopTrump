using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopTrump.Data;
using TopTrump.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace TopTrump.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
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
        [Authorize]
        [HttpPost]
        public IActionResult StartGame(int selectedDeckId, string selectedDifficulty)
        {
            var selectedDeck = _context.Decks
                .Include(d => d.Cards)
                .FirstOrDefault(d => d.DeckId == selectedDeckId);

            if (selectedDeck != null)
            {
                TempData["SelectedDeckId"] = selectedDeckId;
                TempData["SelectedDifficulty"] = selectedDifficulty;

                DistributeCards(selectedDeck);

                return RedirectToAction("SelectStat");
            }

            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult SelectStat()
        {
            int selectedDeckId = Convert.ToInt32(TempData["SelectedDeckId"]);
            var selectedDeck = _context.Decks
                .Include(d => d.Cards)
                .FirstOrDefault(d => d.DeckId == selectedDeckId);

            if (selectedDeck == null)
            {
                return RedirectToAction("Index");
            }

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

        private void DistributeCards(Deck deck)
        {
            var shuffledCards = deck.Cards.OrderBy(x => Guid.NewGuid()).ToList();
            var half = shuffledCards.Count / 2;

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            TempData["BotCards"] = JsonSerializer.Serialize(shuffledCards.Take(half).ToList(), options);
            TempData["PlayerCards"] = JsonSerializer.Serialize(shuffledCards.Skip(half).ToList(), options);
        }


        [Authorize]
        [HttpPost]
        public IActionResult SelectStat(string stat)
        {
            int selectedDeckId = Convert.ToInt32(TempData["SelectedDeckId"]);
            var selectedDeck = _context.Decks
                .Include(d => d.Cards)
                .FirstOrDefault(d => d.DeckId == selectedDeckId);

            if (selectedDeck == null)
            {
                return RedirectToAction("Index");
            }

            var playerHandJson = TempData["PlayerCards"] as string;

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var playerHand = JsonSerializer.Deserialize<List<Card>>(playerHandJson, options);

            var viewModel = new SelectStatViewModel
            {
                Cards = playerHand,
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

        [Authorize]
        public IActionResult PlayRound(int selectedCardId, string SelectedStat)
        {
            Console.WriteLine("Selected card id: " + selectedCardId);
            Console.WriteLine("Selected stat: " + SelectedStat);

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var playerHandJson = TempData["PlayerCards"] as string;
            var botHandJson = TempData["BotCards"] as string;

            var playerHand = JsonSerializer.Deserialize<List<Card>>(playerHandJson, options);
            var botHand = JsonSerializer.Deserialize<List<Card>>(botHandJson, options);

            if (playerHand == null || botHand == null)
            {
                return Json(new { redirectTo = Url.Action("Index", "Game") });
            }

            var playerCard = playerHand.First();
            var botCard = botHand.First();

            string winner = DetermineWinner(playerCard, botCard);

            if (winner == "Player")
            {
                playerHand.Add(botCard);
                botHand.RemoveAt(0);
            }
            else if (winner == "Bot")
            {
                botHand.Add(playerCard);
                playerHand.RemoveAt(0);
            }

            TempData["PlayerCards"] = JsonSerializer.Serialize(playerHand, options);
            TempData["BotCards"] = JsonSerializer.Serialize(botHand, options);

            if (!playerHand.Any() || !botHand.Any())
            {
                Console.WriteLine("Winner is " + winner);
                return Json(new { redirectTo = Url.Action("Index", "Home") });
            }

            var viewModel = new PlayRoundViewModel
            {
                UserCard = playerCard,
                BotCard = botCard,
                Winner = winner
            };

            return PartialView("_PlayRoundResult", viewModel);
        }



        private string DetermineWinner(Card playerCard, Card botCard)
        {
            // Implement your logic to determine the winner based on selectedStat
            // For example, compare the card values
            return "Player"; // Replace with your logic
        }
        [Authorize]
        public IActionResult GameOver(string Winner)
        {
            ViewBag.Winner = Winner;
            return View();
        }
    }
}
