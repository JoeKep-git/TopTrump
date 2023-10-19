using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TopTrump.Models
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public List<Card> UserHand { get; set; } = new List<Card>();

        public Player(string name)
        {
            Name = name;
        }

        public Card PlayCard()
        {
            // Player chooses a card (you can implement player interaction here)
            if (UserHand.Count > 0)
            {
                return UserHand.First();
            }

            return null; // No cards to play
        }

        public void Win(List<Card> cards)
        {
            UserHand.AddRange(cards);
        }
    }
}
