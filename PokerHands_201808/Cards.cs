using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands_201808
{
    public class Cards
    {
        private static Dictionary<string, int> _pointLookup = new Dictionary<string, int>
        {
            {"J", 11},
            {"Q", 12},
            {"K", 13},
            {"A", 14}
        };

        public static IEnumerable<Card> Parse(string cards)
        {
            return cards.Split(',').Select(GetCard);
        }

        private static Card GetCard(string card)
        {
            var realCard = new Card
            {
                Suit = (Suit) (card[0]),
                Point = _pointLookup.ContainsKey(card.Substring(1))
                    ? _pointLookup[card.Substring(1)]
                    : Convert.ToInt32(card.Substring(1))
            };
            return realCard;
        }
    }
}