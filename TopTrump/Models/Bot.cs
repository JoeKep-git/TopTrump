using System.Reflection;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Mono.TextTemplating;

namespace TopTrump.Models
{
    public class Bot
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }

        public Bot(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }
        //Medium difficulty
        public Card PlayCard(string selectedStat, string difficulty)
        {
            try
            {
                //easy mode
                if (difficulty == "Easy")
                {
                    //Order by lowest to highest
                    PropertyInfo statProperty = typeof(Card).GetProperty(selectedStat);
                    if (statProperty != null && statProperty.PropertyType == typeof(int))
                    {
                        Card selectedCard = Hand.OrderBy(card => (int)statProperty.GetValue(card)).FirstOrDefault();
                        if (selectedCard != null)
                        {
                            Hand.Remove(selectedCard);
                        }
                        return selectedCard;
                    }
                }

                //medium difficulty
                else if (difficulty == "Medium")
                {
                    //Pick a random card
                    Random random = new Random();
                    int randomIndex = random.Next(Hand.Count);
                    Card selectedCard = Hand[randomIndex];
                    Hand.RemoveAt(randomIndex);
                    return selectedCard;
                }
                //hard mode
                else if(difficulty == "Hard")
                {
                    //Order by highest to lowest
                    PropertyInfo statProperty = typeof(Card).GetProperty(selectedStat);
                    if (statProperty != null && statProperty.PropertyType == typeof(int))
                    {
                        Card selectedCard = Hand.OrderByDescending(card => (int)statProperty.GetValue(card)).First();
                        Hand.Remove(selectedCard);
                        return selectedCard;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid stat name");
                    }
                }

                return null;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }

}
