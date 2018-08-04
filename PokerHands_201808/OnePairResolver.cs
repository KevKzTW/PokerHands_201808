using System.Linq;

namespace PokerHands_201808
{
    internal class OnePairResolver : ICardKindResolver
    {
        private CardKindResolver _cardKindResolver;
        private int _maxPoint;

        public OnePairResolver(CardKindResolver cardKindResolver)
        {
            _cardKindResolver = cardKindResolver;
        }

        public bool IsMatch()
        {
            var groupBy = _cardKindResolver._cards.GroupBy(c => c.Point);
            var onePair = groupBy.SingleOrDefault(c => c.Count() == 2);
            if (onePair != null)
            {
                _maxPoint = onePair.Key;
                return true;
            }

            return false;
        }

        public void SetResult()
        {
            _cardKindResolver.Kind = CardKind.OnePair;
            _cardKindResolver.MaxPoint = _maxPoint;
        }
    }
}