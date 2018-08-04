using System.Collections.Generic;

namespace PokerHands_201808
{
    public class CardKindResolver
    {
        public IEnumerable<Card> _cards;

        private readonly FlushStraightResolver _flushStraightResolver;
        private readonly FlushResolver _flushResolver;
        private readonly StraightResolver _straightResolver;

        public CardKindResolver(string cards)
        {
            _cards = Cards.Parse(cards);
            foreach (var resolver in GetResolvers())
            {
                if (resolver.IsMatch())
                {
                    resolver.SetResult();
                    return;
                }
            }
       
        }

        private List<ICardKindResolver> GetResolvers()
        {
            List<ICardKindResolver> resolvers = new List<ICardKindResolver>()
            {
                new FlushStraightResolver(this),
                new FlushResolver(this),
                new StraightResolver(this)
            };
            return resolvers;
        }

        public CardKind Kind { get; set; }

        public int MaxPoint { get; set; }
    }
}