using System.Collections.Generic;
using TopTrump.Models;

namespace TopTrump.Models
{
    public class SelectStatViewModel
    {
        public List<Card> UserHand { get; set; }
        public List<Card> Cards { get; set; }
        public List<string> StatNames { get; set; }
        public string SelectedStat { get; set; }
    }
}
