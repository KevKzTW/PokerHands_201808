namespace PokerHands_201808
{
    public class CardCompare
    {
        public static int Compare(string xCards, string yCards)
        {
            var x = new CardKindResolver(xCards);
            var y = new CardKindResolver(yCards);
            if (x.Kind == y.Kind)
            {
                return GetCardComparer(x).Compare(x, y);
            }
            return x.Kind - y.Kind;
        }

        private static ICardComparer GetCardComparer(CardKindResolver x)
        {
            ICardComparer comparer = null;
            if (x.Kind == CardKind.FlushStraight)
            {
                comparer = new FlushStraightComparer();
            }

            return comparer;
        }
    }
}