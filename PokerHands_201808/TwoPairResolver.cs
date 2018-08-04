using System.Linq;

namespace PokerHands_201808
{
    internal class TwoPairResolver : ICardKindResolver
    {
        private CardKindResolver _cardKindResolver;
        private int _maxPoint;

        public TwoPairResolver(CardKindResolver cardKindResolver)
        {
            _cardKindResolver = cardKindResolver;
        }

        public bool IsMatch()
        {
            var pairGroupings = _cardKindResolver._cards.GroupBy(c => c.Point).Where(c => c.Count() == 2);
            var isTwoPair = pairGroupings.Count() == 2;
            if (isTwoPair)
            {
                _maxPoint = pairGroupings.Max(p => p.Key);
                return true;
            }

            return false;
        }

        public void SetResult()
        {
            _cardKindResolver.Kind = CardKind.TwoPair;
            _cardKindResolver.MaxPoint = _maxPoint;
        }
    }
}