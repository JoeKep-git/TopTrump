using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopTrump.Data;
using TopTrump.Models;

public class TestController : Controller {
    private readonly ApplicationDbContext _context;

    public TestController(ApplicationDbContext context) {
        _context = context;
    }

    //Returns the view
    public IActionResult Index(int cardId) {
        //Get card and associated deck data
        var card = _context.Cards
            .Include(c => c.Deck)
            .FirstOrDefault(c => c.CardId == 1);

        // Create the ViewModel and pass the Card object to it
        var viewModel = new CardViewModel {
            Card = card,
            Stat1Name = card.Deck.Stat1,
            Stat2Name = card.Deck.Stat2,
            Stat3Name = card.Deck.Stat3,
            Stat4Name = card.Deck.Stat4
        };

        return View(viewModel);
    }
}