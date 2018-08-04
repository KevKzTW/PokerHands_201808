using System.Linq;

namespace PokerHands_201808
{
    public class FlushStraightResolver : ICardKindResolver
    {
        private CardKindResolver _cardKindResolver;

        public FlushStraightResolver(CardKindResolver cardKindResolver)
        {
            _cardKindResolver = cardKindResolver;
        }

        public bool IsMatch()
        {
            return new FlushResolver(_cardKindResolver).IsMatch() && new StraightResolver(_cardKindResolver).IsMatch();
        }

        public void SetResult()
        {
            this._cardKindResolver.Kind = CardKind.FlushStraight;
            this._cardKindResolver.MaxPoint = this._cardKindResolver._cards.Max<Card>(c => c.Point);
        }
    }
}