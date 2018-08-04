using System.Linq;

namespace PokerHands_201808
{
    internal class FourOfKindsResolver : ICardKindResolver
    {
        private readonly CardKindResolver _cardKindResolver;
        private int _maxPoint;

        public FourOfKindsResolver(CardKindResolver cardKindResolver)
        {
            _cardKindResolver = cardKindResolver;
        }

        public bool IsMatch()
        {
            var groupings = _cardKindResolver._cards.GroupBy(c => c.Point);
            var fourOfKindGrouping = groupings.FirstOrDefault(g => g.Count() == 4);
            if (fourOfKindGrouping != null)
            {
                _maxPoint = fourOfKindGrouping.Key;
                return true;
            }

            return false;
        }

        public void SetResult()
        {
            _cardKindResolver.Kind = CardKind.FourOfKinds;
            _cardKindResolver.MaxPoint = _maxPoint;
        }
    }
}