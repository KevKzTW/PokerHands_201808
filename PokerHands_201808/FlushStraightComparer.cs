namespace PokerHands_201808
{
    public class FlushStraightComparer : ICardComparer
    {
        public int Compare(CardKindResolver x, CardKindResolver y)
        {
            if (x.MaxPoint == y.MaxPoint)
            {
                return x.SecondMaxPoint - y.SecondMaxPoint;
            }
            return x.MaxPoint - y.MaxPoint;
        }
    }
}