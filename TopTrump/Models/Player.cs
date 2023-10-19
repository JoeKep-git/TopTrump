using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TopTrump.Models
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> UserHand { get; set; }

        public Player(string name)
        {
            Name = name;
            UserHand = new List<Card>();
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
