using System.Collections.Generic;
using System.Linq;

namespace PokerHands_201808
{
    public class StraightResolver : ICardKindResolver
    {
        private CardKindResolver _cardKindResolver;

        public StraightResolver(CardKindResolver cardKindResolver)
        {
            _cardKindResolver = cardKindResolver;
        }

        public bool IsMatch()
        {
            var points = _cardKindResolver._cards.Select(a => a.Point);
            var points2 = _cardKindResolver._cards.Select(a => a.IsAce ? 1 : a.Point);
            return IsStraight(points) || IsStraight(points2);
        }

        public void SetResult()
        {
            this._cardKindResolver.Kind = CardKind.Straight;
            this._cardKindResolver.MaxPoint = this._cardKindResolver._cards.Max(c => c.Point);
        }

        private bool IsStraight(IEnumerable<int> points)
        {
            var isStraight = points.Max() - points.Min() == 4 && points.Distinct().Count() == 5;
            return isStraight;
        }
    }
}