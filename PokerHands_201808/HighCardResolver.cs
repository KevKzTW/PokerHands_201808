using System.Linq;

namespace PokerHands_201808
{
    internal class HighCardResolver : ICardKindResolver
    {
        private readonly CardKindResolver _cardKindResolver;

        public HighCardResolver(CardKindResolver cardKindResolver)
        {
            _cardKindResolver = cardKindResolver;
        }

        public bool IsMatch()
        {
            return true;
        }

        public void SetResult()
        {
            _cardKindResolver.Kind = CardKind.HighCard;
            _cardKindResolver.MaxPoint = _cardKindResolver._cards.Max(c => c.Point);
        }
    }
}