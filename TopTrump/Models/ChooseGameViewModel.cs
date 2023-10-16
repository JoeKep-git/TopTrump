using System.Collections.Generic;
using TopTrump.Models;

namespace TopTrump.Models
{
    public class ChooseGameViewModel
    {
        public List<Deck> AvailableDecks { get; set; }
        public string SelectedDifficulty { get; set; }
        public int SelectedDeckId { get; set; }
    }
}
