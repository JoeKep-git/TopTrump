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

        public Card PlayCard()
        {
            Random random = new Random();
            int randomIndex = random.Next(Hand.Count);
            Card selectedCard = Hand[randomIndex];
            Hand.RemoveAt(randomIndex);
            return selectedCard;
        }

        public Card PlayCard(string selectedStat)
        {
            // For simplicity, let's assume the bot selects the card with the highest value for the selected stat
            Card selectedCard = Hand.OrderByDescending(card => card.GetStatValue(selectedStat)).First();
            Hand.Remove(selectedCard);
            return selectedCard;
        }
    }

}
