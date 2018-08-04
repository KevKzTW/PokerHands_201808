using System.Linq;

namespace PokerHands_201808
{
    internal class ThreeOfKindResolver : ICardKindResolver
    {
        private CardKindResolver _cardKindResolver;
        private int _maxPoint;

        public ThreeOfKindResolver(CardKindResolver cardKindResolver)
        {
            _cardKindResolver = cardKindResolver;
        }

        public bool IsMatch()
        {
            var groupBy = _cardKindResolver._cards.GroupBy(c => c.Point);
            var set = groupBy.FirstOrDefault(s => s.Count() == 3);
            if (set != null)
            {
                _maxPoint = set.Key;
                return true;
            }

            return false;
        }

        public void SetResult()
        {
            _cardKindResolver.Kind = CardKind.ThreeOfKind;
            _cardKindResolver.MaxPoint = _maxPoint;
        }
    }
}