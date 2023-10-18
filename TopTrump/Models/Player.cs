using System.ComponentModel.DataAnnotations;

namespace TopTrump.Models
{
    public class Player
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Card> Hand { get; set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }
    }
}
