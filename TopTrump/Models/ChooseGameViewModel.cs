using System.Collections.Generic;
using TopTrump.Models;

namespace TopTrump.Models
{
    public class ChooseGameViewModel
    {
        public int SelectedDeckId { get; set; }
        public string SelectedDifficulty { get; set; }
        public List<Deck> AvailableDecks { get; set; }
        public List<string> DifficultyOptions { get; set; }
    }
}
