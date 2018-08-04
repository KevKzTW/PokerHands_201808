using System.Linq;

namespace PokerHands_201808
{
    internal class FullHouseResolver : ICardKindResolver
    {
        private CardKindResolver _cardKindResolver;
        private int _point;

        public FullHouseResolver(CardKindResolver cardKindResolver)
        {
            _cardKindResolver = cardKindResolver;
        }

        public bool IsMatch()
        {
            var groupings = _cardKindResolver._cards.GroupBy(c => c.Point);
            var set = groupings.FirstOrDefault(g => g.Count() == 3);
            var isFullHouse = set != null && groupings.Any(g => g.Count() == 2);
            if (isFullHouse)
            {
                _point = set.Key;
                return true;
            }
            return false;
        }

        public void SetResult()
        {
            _cardKindResolver.Kind = CardKind.FullHouse;
            _cardKindResolver.MaxPoint = _point;
        }
    }
}