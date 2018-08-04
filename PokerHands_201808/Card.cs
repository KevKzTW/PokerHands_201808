namespace PokerHands_201808
{
    public class Card
    {
       public Suit Suit { get; set; }
        
        public int Point { get; set; }

        public bool IsAce => Point == 14;
    }
}