using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHands_201808
{
    [TestClass]
    public class CardKindTests
    {
        private CardKindResolver _cardKindResolver;

        [TestMethod]
        public void Flush()
        {
            GivenCards("SA,S3,S4,S5,S6");
            ResultShouldBe(CardKind.Flush, 14);
        }

        [TestMethod]
        public void Straight()
        {
            GivenCards("S2,C3,D5,H4,H6");
            ResultShouldBe(cardKind: CardKind.Straight, maxPoint: 6);
        }

        [TestMethod]
        public void Straight_A2345()
        {
            GivenCards("S2,C3,D5,H4,HA");
            ResultShouldBe(CardKind.Straight, 14);
        }

        [TestMethod]
        public void Straight_10JQKA()
        {
            GivenCards("S10,CJ,DK,HQ,HA");
            ResultShouldBe(CardKind.Straight, 14);
        }

        [TestMethod]
        public void Flush_Straight_10JQKA()
        {
            GivenCards("H10,HJ,HK,HQ,HA");
            ResultShouldBe(CardKind.FlushStraight, 14);
        }

        [TestMethod]
        public void FourOfKinds()
        {
            GivenCards("DA,HA,SA,CA,C3");
            ResultShouldBe(CardKind.FourOfKinds, 14);
        }

        [TestMethod]
        public void FullHouse()
        {
            GivenCards("DA,HA,SA,C10,D10");
            ResultShouldBe(CardKind.FullHouse, 14);
        }

        [TestMethod]
        public void FullHouse_66699()
        {
            GivenCards("D6,H6,S6,C9,H9");
            ResultShouldBe(CardKind.FullHouse, 6);
        }

        [TestMethod]
        public void TwoPair()
        {
            GivenCards("D9,H6,C5,H9,C6");
            ResultShouldBe(CardKind.TwoPair, 9);
        }

        [TestMethod]
        public void OnePair()
        {
            GivenCards("D9,H6,C5,H3,C6");
            ResultShouldBe(CardKind.OnePair, 6);
        }

        [TestMethod]
        public void ThreeOfKind()
        {
            GivenCards("DA,CA,SA,D5,S6");
            ResultShouldBe(CardKind.ThreeOfKind, 14);
        }

        [TestMethod]
        public void HighCard()
        {
            GivenCards("DA,C2,S4,D5,S6");
            ResultShouldBe(CardKind.HighCard, 14);
        }

        private void GivenCards(string cards)
        {
            _cardKindResolver = new CardKindResolver(cards);
        }

        private void ResultShouldBe(CardKind cardKind, int maxPoint)
        {
            Assert.AreEqual(cardKind, _cardKindResolver.Kind);
            Assert.AreEqual(maxPoint, _cardKindResolver.MaxPoint);
        }
    }
}