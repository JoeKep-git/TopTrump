namespace TopTrump.Models
{
    public interface IBot
    {
        List<Card> BotHand { get; set; }
        void Win(List<Card> cards);
        Card PlayCard(string selectedStat, string difficulty);
    }
}
