using System.Linq;

namespace PokerHands_201808
{
    public class FlushResolver : ICardKindResolver
    {
        private CardKindResolver _cardKindResolver;

        public FlushResolver(CardKindResolver cardKindResolver)
        {
            _cardKindResolver = cardKindResolver;
        }

        public bool IsMatch()
        {
            return _cardKindResolver._cards.Select(c => c.Suit).Distinct().Count() == 1;
        }

        public void SetResult()
        {
            this._cardKindResolver.Kind = CardKind.Flush;
            this._cardKindResolver.MaxPoint = this._cardKindResolver._cards.Max(c => c.Point);
        }
    }
}