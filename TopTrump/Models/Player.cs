using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

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

        public Card PlayCard(Card card)
        {
            Hand.Remove(card);
            return card;
        }
        //select the stat
        [BindProperty]
        public string SelectedStat { get; set; }
        //when player wins they get the cards that were played that round.
        public void Win(List<Card> cardsWon)
        {
            foreach (var cards in cardsWon)
            {
                Hand.Add(cards);
            }
        }
    }
}
