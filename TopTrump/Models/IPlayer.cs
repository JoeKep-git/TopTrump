namespace TopTrump.Models
{
    public interface IPlayer
    {
        List<Card> UserHand { get; set; }
        void Win(List<Card> cards);
        Card PlayCard();
    }
}
