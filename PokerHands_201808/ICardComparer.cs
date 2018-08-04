namespace PokerHands_201808
{
    public interface ICardComparer
    {
        int Compare(CardKindResolver x, CardKindResolver y);
    }
}