using System;
using System.Collections.Generic;
using System.Linq;

namespace TopTrump.Models
{
    public class Bot
    {
        public string Name { get; set; }
        public List<Card> BotHand { get; set; }

        public Bot(string name)
        {
            Name = name;
            BotHand = new List<Card>();
        }

        public Card PlayCard(string selectedStat, string difficulty)
        {
            if (difficulty == "Easy")
            {
                // Bot chooses the card with the lowest value for the selected stat
                return BotHand.OrderBy(card => card.GetStatValue(selectedStat)).First();
            }
            else if (difficulty == "Medium")
            {
                // Bot chooses a random card from its hand
                Random random = new Random();
                int index = random.Next(BotHand.Count);
                return BotHand[index];
            }
            else if (difficulty == "Hard")
            {
                // Bot chooses the card with the highest value for the selected stat
                return BotHand.OrderByDescending(card => card.GetStatValue(selectedStat)).First();
            }

            // Default: Bot chooses a random card
            Random rand = new Random();
            int randomIndex = rand.Next(BotHand.Count);
            return BotHand[randomIndex];
        }

        public void Win(List<Card> cards)
        {
            BotHand.AddRange(cards);
        }
    }


}
