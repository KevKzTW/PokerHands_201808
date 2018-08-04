using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHands_201808
{
    [TestClass]
    public class CardCompareTests
    {
        [TestMethod]
        public void FlushStraight_Bigger_Than_FourOfKind()
        {
            var flushStraightCards = "DA,D2,D3,D4,D5";
            var fourOfKindCards = "DA,SA,HA,ZA,D9";

            FirstBiggerThanSecond(flushStraightCards, fourOfKindCards);
        }

        private static void FirstBiggerThanSecond(string flushStraightCards, string fourOfKindCards)
        {
            Assert.IsTrue(CardCompare.Compare(flushStraightCards, fourOfKindCards) > 0);
        }

        [TestMethod]
        public void Both_FlushStraight()
        {
            var x = "C3,C4,C5,C6,C7";
            var y = "D2,D3,D4,D5,D6";
            FirstBiggerThanSecond(x, y);
        }

        [TestMethod]
        public void Both_FlushStraight_A2345_10JKQA()
        {
            var x = "C10,CJ,CQ,CK,CA";
            var y = "D2,D3,D4,D5,DA";
            FirstBiggerThanSecond(x, y);
        }
    }
}