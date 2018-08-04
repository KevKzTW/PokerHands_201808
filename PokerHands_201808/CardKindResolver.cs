using System.Collections.Generic;
using System.Linq;

namespace PokerHands_201808
{
    public class CardKindResolver
    {
        private IEnumerable<Card> _cards;

        public CardKindResolver(string cards)
        {
            _cards = Cards.Parse(cards);
            if (IsFlush())
            {
                kind = CardKind.Flush;
            }

            if (IsStraight())
            {
                kind = CardKind.Straight;
            }

            MaxPoint = _cards.Max(c => c.Point);
        }

        private bool IsFlush()
        {
            return _cards.Select(c => c.Suit).Distinct().Count() == 1;
        }

        private bool IsStraight()
        {
            var points = _cards.Select(a => a.Point);
            var points2 = _cards.Select(a => a.IsAce ? 1 : a.Point);
            return IsStraight(points) || IsStraight(points2);
        }

        private static bool IsStraight(IEnumerable<int> points)
        {
            var isStraight = points.Max() - points.Min() == 4 && points.Distinct().Count() == 5;
            return isStraight;
        }

        private CardKind kind;

        public CardKind GetKind()
        {          
            return kind;
        }

        public int MaxPoint { get; }
    }
}