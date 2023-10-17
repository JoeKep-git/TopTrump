using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopTrump.Data;
using TopTrump.Models;

public class TestController : Controller {
    private readonly ApplicationDbContext _context;

    public TestController(ApplicationDbContext context) {
        _context = context;
    }

    //Returns the view
    public IActionResult Index(int cardId) {
        // Retrieve the Card object from the database based on cardId
        Card card = _context.Cards.FirstOrDefault(c => c.CardId == 2);

        // Create the ViewModel and pass the Card object to it
        var viewModel = new CardViewModel {
            Card = card
        };

        return View(viewModel);
    }
}