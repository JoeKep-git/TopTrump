using TopTrump.Models;

namespace TopTrump.Models
{
    public class PlayRoundViewModel
    {
        public Card UserCard { get; set; }
        public Card BotCard { get; set; }
        public string Winner { get; set; }
    }
}
