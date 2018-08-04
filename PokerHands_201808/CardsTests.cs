using System.Collections.Generic;
using System.Linq;
using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHands_201808
{
    [TestClass]
    public class CardsTests
    {
        [TestMethod]
        public void ParseSuit()
        {
            var cards = Cards.Parse("S3,C9,D5,D2,H7");
            var expected = new List<Card>
            {
                new Card {Suit = Suit.Spade, Point = 3},
                new Card {Suit = Suit.Club, Point = 9},
                new Card {Suit = Suit.Diamond, Point = 5},
                new Card {Suit = Suit.Diamond, Point = 2},
                new Card {Suit = Suit.Heart, Point = 7}
            };

            expected.ToExpectedObject().ShouldEqual(cards.ToList());
        }


        [TestMethod]
        public void Parse10JQKA()
        {
            var cards = Cards.Parse("S10,SJ,CQ,DK,HA");
            var expected = new List<Card>
            {
                new Card {Suit = Suit.Spade, Point = 10},
                new Card {Suit = Suit.Spade, Point = 11},
                new Card {Suit = Suit.Club, Point = 12},
                new Card {Suit = Suit.Diamond, Point = 13},
                new Card {Suit = Suit.Heart, Point = 14},
            };

            expected.ToExpectedObject().ShouldEqual(cards.ToList());

        }
    }
}